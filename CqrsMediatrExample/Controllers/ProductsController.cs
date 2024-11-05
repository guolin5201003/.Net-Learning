using CqrsMediatrExample.Commands;
using CqrsMediatrExample.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatrExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet(Name = "GetProducts")]
        public async Task<ActionResult> GetProducts()
        {
            var products = mediator.Send(new GetProductsQuery());
            return Ok(products);
        }
        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody]Product product)
        {
            var cmd = new AddProductCommand();
            cmd.Product = product;
            var result = await mediator.Send(cmd);

            await mediator.Publish(new ProductAddedNotification { Product = product });

            await mediator.Publish(new ProductAddedTransactionNotification { Product = product });

            return CreatedAtRoute("GetProductById", new { id = result.Id }, result);
        }
        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await mediator.Send(new GetProductByIdQuery { Id = id });
            return Ok(product);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody]Product product)
        {
            var result = await mediator.Send(new UpdateProductCommand { Product = product });
            return CreatedAtRoute("GetProductById", new { id = result.Id }, result);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var result = await mediator.Send(new DeleteProductCommand { Id = id });
            if (!result)
            {
                return NotFound();
            }
            return CreatedAtRoute("GetProducts", null, result);
        }

    }
}
