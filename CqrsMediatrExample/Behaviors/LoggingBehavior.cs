using CqrsMediatrExample.Queries;
using MediatR;
using System.Diagnostics;

namespace CqrsMediatrExample.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            this.logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Stopwatch sw = Stopwatch.StartNew();
            logger.LogInformation("Processing request: {@request}", request);
            var response = await next();
            logger.LogInformation("Processed request: {@request}, response: {@response}, elasped: {@Elapsed}ms", request, response,sw.ElapsedMilliseconds);
            return response;
        }
    }
}
