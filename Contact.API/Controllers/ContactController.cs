using Contact.Application.Handlers.ContactHandler.Command;
using Contact.Application.Handlers.ContactHandler.Queries;
using Contact.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Contact.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromForm]  CreateContactDto createContactDto)
    {
        var result = await Mediator.Send(new CreateContactCommand() { UserId = createContactDto.UserId, ContactTypeId = createContactDto.ContactTypeId, Value = createContactDto.Value});
        if (result.Success)
        {
            return Ok(result);

        }
        return BadRequest(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete([FromForm] Guid userId)
    {
        var result = await Mediator.Send(new DeleteContactCommand() {UserId = userId});
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result.Message);
    }
    
    [HttpPost("detail")]
    public async Task<IActionResult> Create([FromForm] Guid userId)
    {
        var result = await Mediator.Send(new GetUserContactDetailQuery() { UserId = userId});
        if (result.Success)
        {
            return Ok(result);

        }
        return BadRequest(result);
    }
}