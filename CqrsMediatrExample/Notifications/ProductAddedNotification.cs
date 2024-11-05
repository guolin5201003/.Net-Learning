using MediatR;

namespace CqrsMediatrExample
{
    public class ProductAddedNotification:INotification
    {
        public Product Product { get; set; }
    }
}
