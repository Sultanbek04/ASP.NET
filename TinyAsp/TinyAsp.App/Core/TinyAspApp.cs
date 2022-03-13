using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TinyAsp.App.Core.Models;

namespace TinyAsp.App.Core
{

    public class ProcessRequest
    {
        private string ReadBodyContent(HttpListenerRequest request)
        {
            using (var sr = new StreamReader(request.InputStream))
            {
                return sr.ReadToEnd();
            }
        }

        private ParameterInfo GetFromBodyAttribute(MethodInfo method)
        {
            return method.GetParameters().FirstOrDefault(p => p.GetCustomAttribute<FromBodyAttribute>() != null);
        }

        private object CreateInstanceOfController(string controllerName)
        {
            var callingAssembly = Assembly.GetEntryAssembly();
            var controller = Activator.CreateInstance(callingAssembly.GetName().ToString(), controllerName) as ObjectHandle;
            var target = (object)controller.Unwrap();
            return target;
        }

        private static Dictionary<string, string> ToDictionary(NameValueCollection nvc)
        {
            return nvc.AllKeys.ToDictionary(k => k, k => nvc[k]);
        }


        public void GetBodyContent(
        HttpListenerRequest requestContext,
        HttpListenerResponse responseContext,
        SemaphoreSlim concurrentRequestProcessorSemaphore,
        RouteToActionMapping targetAction)
        {
            var requestId = Guid.NewGuid();

            Console.WriteLine($"Started processing incoming request {requestId} at thread # " +
                    $"{Thread.CurrentThread.ManagedThreadId}");

            var controller = CreateInstanceOfController(targetAction.AssociatedController);

            var toControllerBaseClass = controller as Controller;
            foreach(var header in ToDictionary(requestContext.Headers))
            {
                toControllerBaseClass.AddCurrentRequestHeader(header.Key, header.Value);
            }

            var action = controller.GetType().GetMethod(targetAction.AssociatedAction);
            var parametr = GetFromBodyAttribute(action);
            var convert = default(object);

            ActionResult controllerResponseDefault = default;

            if (parametr != null)
            {
                var bodyContent = ReadBodyContent(requestContext);
                convert = JsonConvert.DeserializeObject(bodyContent, parametr.ParameterType);
                action.Invoke(controller, new object[] { convert });
            }
            else
            {
                controllerResponseDefault = (ActionResult) action.Invoke(controller, null);
            }

            if (controllerResponseDefault != null)
            {
                var content = Encoding.UTF8.GetBytes(controllerResponseDefault.ExecuteResult());
                responseContext.OutputStream.Write(content, 0, content.Length);
            }

            responseContext.StatusCode = (int)HttpStatusCode.OK;
            responseContext.Close();

            Console.WriteLine($"Completed processing incoming request {requestId} at thread # " +
                    $"{Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine("Semaphore +1");
            concurrentRequestProcessorSemaphore.Release();
        }
    }


    public class TinyAspApp
    {
        private readonly HttpListener _httpListener;
        private readonly IReadOnlyDictionary<string, RouteToActionMapping> _routeToActionMappings;

        private const int MaxConcurrentRequestProcessorCount = 10;
        private readonly SemaphoreSlim _concurrentRequestProcessorSemaphore;
        private static string GetLocalhostPrefix(int port) => $"http://127.0.0.1:{port}/";
        public TinyAspApp(int port)
        {
            _httpListener = new HttpListener();
            _httpListener.Prefixes.Add(GetLocalhostPrefix(port));

            var callingAssembly = Assembly.GetCallingAssembly();
            _routeToActionMappings = RouteDiscovery.GetDiscoveredRoutesFromAssembly(callingAssembly);

            _concurrentRequestProcessorSemaphore =
                    new SemaphoreSlim(MaxConcurrentRequestProcessorCount);
        }
        /*private ParameterInfo GetFromBodyAttribute(MethodInfo method) {
			return method.GetParameters().FirstOrDefault(p => p.GetCustomAttribute<FromBodyAttribute>() != null);
		}
		private string ReadBodyContent(HttpListenerRequest request) {
			using (var sr = new StreamReader(request.InputStream)) {
				return sr.ReadToEnd();
			}
		}
		private object CreateInstanceOfController(string controllerName) {
			var callingAssembly = Assembly.GetEntryAssembly();
			var controller = Activator.CreateInstance(callingAssembly.GetName().ToString(), controllerName) as ObjectHandle;
			var target = (object)controller.Unwrap();
			return target;
		}

		private void ProcessRequest(
				HttpListenerRequest requestContext,
				HttpListenerResponse responseContext,
				SemaphoreSlim concurrentRequestProcessorSemaphore,
				RouteToActionMapping targetAction) {
			var requestId = Guid.NewGuid();

			Console.WriteLine($"Started processing incoming request {requestId} at thread # " +
					$"{Thread.CurrentThread.ManagedThreadId}");

			var controller = CreateInstanceOfController(targetAction.AssociatedController);
			var action = controller.GetType().GetMethod(targetAction.AssociatedAction);
			var parametr = GetFromBodyAttribute(action);
			var convert = default(object);
			if (parametr != null) {
				var bodyContent = ReadBodyContent(requestContext);
				convert = JsonConvert.DeserializeObject(bodyContent, parametr.ParameterType);	
			}
			action.Invoke(controller, new object[] { convert });
			Thread.Sleep(TimeSpan.FromSeconds(10));

			var content = Encoding.UTF8.GetBytes(requestId.ToString());
			responseContext.OutputStream.Write(content, 0, content.Length);
			responseContext.StatusCode = (int)HttpStatusCode.OK;
			responseContext.Close();

			Console.WriteLine($"Completed processing incoming request {requestId} at thread # " +
					$"{Thread.CurrentThread.ManagedThreadId}");

			Console.WriteLine("Semaphore +1");
			concurrentRequestProcessorSemaphore.Release();
		}*/

        public void Run()
        {
            _httpListener.Start();

            // Event Loop
            while (_httpListener.IsListening)
            {
                var context = _httpListener.GetContext();

                var request = context.Request;
                var response = context.Response;

                var requestRawUrl = request.RawUrl.ToLower();
                if (_routeToActionMappings.ContainsKey(requestRawUrl))
                {
                    var requestProcessingStatus = RequestProcessingStatusFactory.GetRequestProcessingStatus();
                    if (requestProcessingStatus.CanTakeToProcessing)
                    {
                        Console.WriteLine("Semaphore -1");

                        try
                        {
                            var processRequestTask = Task.Run(() =>
                            {
                                var getBodyContent = new ProcessRequest();
                                getBodyContent.GetBodyContent(request, response, _concurrentRequestProcessorSemaphore, _routeToActionMappings[requestRawUrl]);
                                //ProcessRequest(
                                //	request, response, _concurrentRequestProcessorSemaphore, _routeToActionMappings[requestRawUrl]);
                            });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Semaphore +1");
                            _concurrentRequestProcessorSemaphore.Release();
                        }
                    }
                    else
                    {
                        Console.WriteLine(requestProcessingStatus.Exception.Message);
                        response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                        response.Close();
                    }
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Close();
                }

                Console.WriteLine("Incoming request");
            }
        }
    }
}
