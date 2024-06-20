using Application.Features.BillingAddresses.Commands.Create;
using Application.Features.BillingAddresses.Commands.Delete;
using Application.Features.BillingAddresses.Commands.Update;
using Application.Features.BillingAddresses.Queries.GetById;
using Application.Features.BillingAddresses.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BillingAddressesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBillingAddressCommand createBillingAddressCommand)
    {
        CreatedBillingAddressResponse response = await Mediator.Send(createBillingAddressCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBillingAddressCommand updateBillingAddressCommand)
    {
        UpdatedBillingAddressResponse response = await Mediator.Send(updateBillingAddressCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedBillingAddressResponse response = await Mediator.Send(new DeleteBillingAddressCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdBillingAddressResponse response = await Mediator.Send(new GetByIdBillingAddressQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBillingAddressQuery getListBillingAddressQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBillingAddressListItemDto> response = await Mediator.Send(getListBillingAddressQuery);
        return Ok(response);
    }
}