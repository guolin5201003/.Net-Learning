using MediatR;

namespace CqrsMediatrExample.Commands
{
    public class DeleteProductCommand:IRequest<bool>, ICommandRequest
    {
        public int Id { get; set; }
    }
}
