using System.Diagnostics;
using Euvic.StaffTraining.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Euvic.StaffTraining.Infrastructure.Metrics
{
    public class PerformanceMeasurementBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<PerformanceMeasurementBehavior<TRequest, TResponse>> _logger;

        public PerformanceMeasurementBehavior(ILogger<PerformanceMeasurementBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response = default;
            if (request.RequirePerformanceCheck())
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();

                response = await next();

                stopWatch.Stop();

                _logger.LogDebug("{TRequest} was executed within {miliseconds} ms", typeof(TRequest).FullName, stopWatch.ElapsedMilliseconds);
            }
            else
            {
                response = await next();
            }

            return response;
        }
    }
}
