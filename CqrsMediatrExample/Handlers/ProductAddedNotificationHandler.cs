using MediatR;

namespace CqrsMediatrExample.Handlers
{
    public class ProductAddedNotificationHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly ILogger<ProductAddedNotificationHandler> logger;

        public ProductAddedNotificationHandler(ILogger<ProductAddedNotificationHandler> logger)
        {
            this.logger = logger;
        }
        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Product {@Product} added", notification.Product);
            await Task.CompletedTask;
        }
    }
}
