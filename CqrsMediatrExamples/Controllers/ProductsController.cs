using CqrsMediatrExamples.Commands;
using CqrsMediatrExamples.Entities;
using CqrsMediatrExamples.Notifications;
using CqrsMediatrExamples.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace CqrsMediatrExamples.Controllers
{
    [Route("api/products")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetProductsQuery());

            return Ok(products);
        }


        [HttpGet("{id:int}",Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var products = await _mediator.Send(new GetProductByIdQuery(id));

            return Ok(products);
        }


        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody]Product product)
        {
            var productToReturn = await _mediator.Send(new AddProductCommand(product));

            await _mediator.Publish(new ProductAddedNotification(productToReturn));

            return CreatedAtRoute("GetProductById", new {id = productToReturn.Id},
                productToReturn);
        }
    }
}
