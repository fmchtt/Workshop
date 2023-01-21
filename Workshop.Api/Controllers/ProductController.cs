using Flunt.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workshop.Domain.DTO.Output.Generic;
using Workshop.Domain.DTO.Input.ProductDTO;
using Workshop.Domain.DTO.Output.ProductDTO;
using Workshop.Domain.Repositories;
using Workshop.Domain.UseCases.ProductUseCases;

namespace Workshop.Api.Controllers;

using NotificationList = IReadOnlyCollection<Notification>;

[ApiController, Route("products")]
public class ProductController : WorkshopBaseController
{
    [HttpGet("{id}"), Authorize]
    [ProducesResponseType(typeof(ProductResultDTO), 200)]
    [ProducesResponseType(typeof(MessageResult), 404)]
    public dynamic GetProduct(
        [FromServices] IProductRepository productRepository,
        [FromServices] IEmployeeRepository employeeRepository,
        string id
    )
    {
        var employee = employeeRepository.GetByUserId(GetUserId());
        var product = productRepository.GetByID(Guid.Parse(id), employee.CompanyId);
        if (product == null)
        {
            return NotFound("Produto não encontrado!");
        }

        return Ok(new ProductResultDTO(product));
    }

    [HttpGet, Authorize]
    public List<ProductResultDTO> GetProducts(
        [FromServices] IProductRepository productRepository,
        [FromServices] IEmployeeRepository employeeRepository
    )
    {
        var employee = employeeRepository.GetByUserId(GetUserId());
        var product = productRepository.GetAll(employee.CompanyId);

        var products = new List<ProductResultDTO>();
        foreach (var item in product)
        {
            products.Add(new ProductResultDTO(item));
        }

        return Ok(products);
    }

    [HttpPost, Authorize]
    [ProducesResponseType(typeof(ProductResultDTO), 200)]
    [ProducesResponseType(typeof(NotificationList), 400)]
    [ProducesResponseType(typeof(MessageResult), 401)]
    [ProducesResponseType(typeof(MessageResult), 404)]
    public dynamic CreateProduct(
        [FromBody] CreateProductDTO data,
        [FromServices] IProductRepository productRepository,
        [FromServices] IEmployeeRepository employeeRepository
    )
    {
        var result = new CreateProductUseCase(productRepository, employeeRepository).Handle(data, GetUserId());

        return ParseResult(result);
    }
}
