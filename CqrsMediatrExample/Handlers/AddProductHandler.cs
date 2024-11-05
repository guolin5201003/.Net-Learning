using CqrsMediatrExample.Commands;
using MediatR;

namespace CqrsMediatrExample.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        public AddProductHandler(FakeDataStore fakeDataStore, IMediator mediator)        
        {
            this.fakeDataStore = fakeDataStore;
            this.mediator = mediator;
        }

        private readonly FakeDataStore fakeDataStore;
        private readonly IMediator mediator;

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await fakeDataStore.AddProduct(request.Product);

            await mediator.Publish(new ProductAddedNotification { Product = request.Product });

            await mediator.Publish(new ProductAddedTransactionNotification { Product = request.Product });


            return request.Product;
        }
    }
}
