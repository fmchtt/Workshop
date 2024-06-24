using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workshop.Application.Results;
using Workshop.Application.Results.Stock;
using Workshop.Application.Stock.Products.Create;
using Workshop.Application.Stock.Products.Delete;
using Workshop.Application.Stock.Products.GetAll;
using Workshop.Application.Stock.Products.GetById;
using Workshop.Application.Stock.Products.Update;

namespace Workshop.Api.Controllers;
[ApiController, Route("products"), Authorize]
public class ProductController(IMediator mediator, IMapper mapper) : WorkshopBaseController(mediator, mapper)
{
    [HttpGet("{id}")]
    public async Task<ProductResult> GetProduct(
        [FromRoute] Guid id
    )
    {
        var query = new GetProductByIdQuery { Actor = await GetUser(), ProductId = id };
        return _mapper.Map<ProductResult>(await _mediator.Send(query));
    }

    [HttpGet]
    public async Task<ICollection<ProductResult>> GetProducts()
    {
        var query = new GetAllProductsQuery { Actor = await GetUser() };
        return _mapper.Map<ICollection<ProductResult>>(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<ProductResult> CreateProduct(
        [FromBody] CreateProductCommand command
    )
    {
        command.Actor = await GetUser();
        return _mapper.Map<ProductResult>(await _mediator.Send(command));
    }

    [HttpPatch("{id}")]
    public async Task<ProductResult> UpdateProduct(
        [FromRoute] Guid id,
        [FromBody] UpdateProductCommand command
    )
    {
        command.Actor = await GetUser();
        command.ProductId = id;
        return _mapper.Map<ProductResult>(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<MessageResult> DeleteProduct(
        [FromRoute] Guid id
    )
    {
        var command = new DeleteProductCommand { Actor = await GetUser(), ProductId = id };
        return new MessageResult(await _mediator.Send(command));
    }
}
