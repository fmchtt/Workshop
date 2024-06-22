using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workshop.Application.Results.Stock;
using Workshop.Application.Stock.Products.Create;
using Workshop.Application.Stock.Products.GetAll;
using Workshop.Application.Stock.Products.GetById;

namespace Workshop.Api.Controllers;
[ApiController, Route("products")]
public class ProductController(IMediator mediator, IMapper mapper) : WorkshopBaseController(mediator, mapper)
{
    [HttpGet("{id}"), Authorize]
    public async Task<ProductResult> GetProduct(
        [FromRoute] Guid id
    )
    {
        var query = new GetProductByIdQuery { Actor = await GetUser(), ProductId = id };
        return _mapper.Map<ProductResult>(await _mediator.Send(query));
    }

    [HttpGet, Authorize]
    public async Task<ICollection<ProductResult>> GetProducts()
    {
        var query = new GetAllProductsQuery { Actor = await GetUser() };
        return _mapper.Map<ICollection<ProductResult>>(await _mediator.Send(query));
    }

    [HttpPost, Authorize]
    public async Task<ProductResult> CreateProduct(
        [FromBody] CreateProductCommand command
    )
    {
        command.Actor = await GetUser();
        return _mapper.Map<ProductResult>(await _mediator.Send(command));
    }
}
