using MediatR;

namespace CqrsMediatrExample
{
    public class ProductAddedTransactionNotification:INotification
    {
        public Product Product { get; set; }
    }
}
