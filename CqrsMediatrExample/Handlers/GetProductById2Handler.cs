using CqrsMediatrExample.Queries;
using MediatR;

namespace CqrsMediatrExample.Handlers
{
    public class GetProductById2Handler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly FakeDataStore fakeDataStore;

        public GetProductById2Handler(FakeDataStore fakeDataStore)
        {
            this.fakeDataStore = fakeDataStore;
        }
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await fakeDataStore.GetProductById(request.Id);
        }
    }
}
