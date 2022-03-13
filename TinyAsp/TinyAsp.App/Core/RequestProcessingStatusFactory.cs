using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TinyAsp.App.Core
{
    internal class RequestProcessingStatusContainer
    {
        public bool CanTakeToProcessing { get; private set; }
        public Exception Exception { get; private set; }
        public RequestProcessingStatusContainer(
            bool canTakeToProcessing, Exception exception = null)
        {
            CanTakeToProcessing = canTakeToProcessing;
            Exception = exception;
        }
    }

    internal static class RequestProcessingStatusFactory
    {
        private const int MaxConcurrentRequestProcessorCount = 10;
        private const int MaxAwaitForProcessingThreadTimeoutMilliseconds = 10;

        private static readonly SemaphoreSlim _concurrentRequestProcessorSemaphore = 
            new(MaxConcurrentRequestProcessorCount);

        public static RequestProcessingStatusContainer GetRequestProcessingStatus()
        {
            var canTakeToProcessing = _concurrentRequestProcessorSemaphore
                .Wait(MaxAwaitForProcessingThreadTimeoutMilliseconds);

            if (canTakeToProcessing)
            {
                return new RequestProcessingStatusContainer(canTakeToProcessing);
            }
            else
            {
                var exception = new InvalidOperationException(
                    "Cannot take incoming request for processing, too many requests!");
                return new RequestProcessingStatusContainer(canTakeToProcessing, exception);
            }
        }
    }
}
