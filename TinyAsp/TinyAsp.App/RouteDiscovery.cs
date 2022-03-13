using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using TinyAsp.App.Core.Models;

namespace TinyAsp.App {
	public class RouteDiscovery {
		private static Type[] GetHttpMethodsToDiscover() =>
				new Type[]
				{
								typeof(HttpGetAttribute),
								typeof(HttpPostAttribute)
				};

		/// <summary>
		/// api/departments : { DepartmentController, GetAllDepartments, HttpGet }
		/// </summary>
		public static IReadOnlyDictionary<string, RouteToActionMapping>
				GetDiscoveredRoutesFromAssembly(Assembly assembly) {
			var routes = new Dictionary<string, RouteToActionMapping>();

			// Type = { Class, Struct, Interface, Delegate, Enum }
			var controllers = assembly.GetTypes()
					.Where(p => p.IsClass && !p.IsAbstract &&
							typeof(Controller).IsAssignableFrom(p));

			foreach (var controller in controllers) {
				var routeAttribute = controller
						.GetCustomAttribute<RouteAttribute>();

				if (routeAttribute != null) {
					var route = "/" + routeAttribute.Route.ToLower();

					var methods = controller
							.GetMethods(BindingFlags.Instance | BindingFlags.Public);

					foreach (var method in methods) {
						var containsHttpMethodAttribute = method
								.GetCustomAttributes()
										.Any(p => GetHttpMethodsToDiscover()
												.Contains(p.GetType()));

						if (containsHttpMethodAttribute) {
							routes.Add(route, new RouteToActionMapping {
								AssociatedController = controller.FullName,
								AssociatedAction = method.Name,
								AssociatedHttpMethod = typeof(HttpGetAttribute).FullName
							});
						}
					}
				}
			}
			return routes;
		}
	}
}
