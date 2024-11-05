using MediatR;

namespace CqrsMediatrExample.Commands
{
    public class AddProductCommand:IRequest<Product>
    {

        public Product Product { get; set; }
    }
}
