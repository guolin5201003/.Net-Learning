using MediatR;

namespace CqrsMediatrExample.Commands
{
    public class UpdateProductCommand:IRequest<Product>
    {
        public Product Product { get; set; }
    }
}
