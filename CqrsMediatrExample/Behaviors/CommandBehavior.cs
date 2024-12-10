using CqrsMediatrExample.Commands;
using MediatR;

namespace CqrsMediatrExample.Behaviors
{
    public class CommandBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommandRequest
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> logger;

        public CommandBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            this.logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation("Executing command {@request}", request);
            var response = await next();
            logger.LogInformation("Executed command {@request}, Response: {@response}", request, response);
            return response;
        }
    }
}
