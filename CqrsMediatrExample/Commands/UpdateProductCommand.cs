using MediatR;

namespace CqrsMediatrExample.Commands
{
    public class UpdateProductCommand: IRequest<Product>, ICommandRequest
    {
        public Product Product { get; set; }
    }
}
