using MediatR;

namespace CqrsMediatrExample
{
    public class GetProductsQuery:IRequest<IEnumerable<Product>>
    {
    }
}
