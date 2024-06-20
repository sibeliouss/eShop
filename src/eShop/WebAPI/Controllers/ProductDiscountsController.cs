using Application.Features.ProductDiscounts.Commands.Create;
using Application.Features.ProductDiscounts.Commands.Delete;
using Application.Features.ProductDiscounts.Commands.Update;
using Application.Features.ProductDiscounts.Queries.GetById;
using Application.Features.ProductDiscounts.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductDiscountsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductDiscountCommand createProductDiscountCommand)
    {
        CreatedProductDiscountResponse response = await Mediator.Send(createProductDiscountCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductDiscountCommand updateProductDiscountCommand)
    {
        UpdatedProductDiscountResponse response = await Mediator.Send(updateProductDiscountCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedProductDiscountResponse response = await Mediator.Send(new DeleteProductDiscountCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdProductDiscountResponse response = await Mediator.Send(new GetByIdProductDiscountQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductDiscountQuery getListProductDiscountQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProductDiscountListItemDto> response = await Mediator.Send(getListProductDiscountQuery);
        return Ok(response);
    }
}