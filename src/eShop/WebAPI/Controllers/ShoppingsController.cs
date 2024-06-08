using Application.Features.Shoppings.Commands.Create;
using Application.Features.Shoppings.Commands.Delete;
using Application.Features.Shoppings.Commands.Update;
using Application.Features.Shoppings.Queries.GetById;
using Application.Features.Shoppings.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShoppingsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateShoppingCommand createShoppingCommand)
    {
        CreatedShoppingResponse response = await Mediator.Send(createShoppingCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateShoppingCommand updateShoppingCommand)
    {
        UpdatedShoppingResponse response = await Mediator.Send(updateShoppingCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedShoppingResponse response = await Mediator.Send(new DeleteShoppingCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdShoppingResponse response = await Mediator.Send(new GetByIdShoppingQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListShoppingQuery getListShoppingQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListShoppingListItemDto> response = await Mediator.Send(getListShoppingQuery);
        return Ok(response);
    }
}