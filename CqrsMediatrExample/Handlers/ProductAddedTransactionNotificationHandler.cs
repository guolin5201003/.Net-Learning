using MediatR;

namespace CqrsMediatrExample.Handlers
{
    public class ProductAddedTransactionNotificationHandler : INotificationHandler<ProductAddedTransactionNotification>
    {
        private readonly ILogger<ProductAddedTransactionNotificationHandler> logger;

        public ProductAddedTransactionNotificationHandler(ILogger<ProductAddedTransactionNotificationHandler> logger)
        {
            this.logger = logger;
        }
        public async Task Handle(ProductAddedTransactionNotification notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Product {@Product} added to transaction", notification.Product);
            await Task.CompletedTask;
        }
    }
}
