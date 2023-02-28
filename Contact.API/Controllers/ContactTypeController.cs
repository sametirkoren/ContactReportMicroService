using Contact.Application.Handlers.ContactHandler.Command;
using Contact.Application.Handlers.ContactHandler.Queries;
using Contact.Application.Handlers.ContactTypeHandler.Command;
using Contact.Application.Handlers.ContactTypeHandler.Queries;
using Contact.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Contact.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ContactTypeController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromForm]  CreateContactTypeDto createContactTypeDto)
    {
        var result = await Mediator.Send(new CreateContactTypeCommand() { Name = createContactTypeDto.Name});
        if (result.Success)
        {
            return Ok(result);

        }
        return BadRequest(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete([FromForm] Guid contactTypeId)
    {
        var result = await Mediator.Send(new DeleteContactTypeCommand() { ContactTypeId = contactTypeId});
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result.Message);
    }
    
    [HttpGet("id")]
    public async Task<IActionResult> GetContactType([FromForm] Guid contactTypeId)
    {
        var result = await Mediator.Send(new GetContactTypeQuery(){ContactTypeId = contactTypeId});
        if (result.Success)
        {

            return Ok(result);
        }
        return BadRequest(result.Message);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var result = await Mediator.Send(new GetContactTypesQuery());
        if (result.Success)
        {

            return Ok(result);
        }
        return BadRequest(result.Message);
    }
    
}