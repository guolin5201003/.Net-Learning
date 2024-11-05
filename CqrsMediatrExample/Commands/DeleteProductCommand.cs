using MediatR;

namespace CqrsMediatrExample.Commands
{
    public class DeleteProductCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
