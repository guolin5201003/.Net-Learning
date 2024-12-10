using MediatR;

namespace CqrsMediatrExample.Commands
{
    public class AddProductCommand:IRequest<Product>, ICommandRequest
    {

        public Product Product { get; set; }
    }
}
