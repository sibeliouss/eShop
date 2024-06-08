using Application.Features.OrderInformations.Commands.Create;
using Application.Features.OrderInformations.Commands.Delete;
using Application.Features.OrderInformations.Commands.Update;
using Application.Features.OrderInformations.Queries.GetById;
using Application.Features.OrderInformations.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderInformationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateOrderInformationCommand createOrderInformationCommand)
    {
        CreatedOrderInformationResponse response = await Mediator.Send(createOrderInformationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOrderInformationCommand updateOrderInformationCommand)
    {
        UpdatedOrderInformationResponse response = await Mediator.Send(updateOrderInformationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedOrderInformationResponse response = await Mediator.Send(new DeleteOrderInformationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdOrderInformationResponse response = await Mediator.Send(new GetByIdOrderInformationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListOrderInformationQuery getListOrderInformationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListOrderInformationListItemDto> response = await Mediator.Send(getListOrderInformationQuery);
        return Ok(response);
    }
}