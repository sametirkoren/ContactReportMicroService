using Contact.Application.Handlers.UserHandler.Command;
using Contact.Application.Handlers.UserHandler.Queries;
using Contact.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Contact.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UserController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateUserDto createUserDto)
    {
        var result = await Mediator.Send(new CreateUserCommand() {FirstName = createUserDto.FirstName, Surname = createUserDto.Surname, Company = createUserDto.Company});
        if (result.Success)
        {
            return Ok(result);

        }
        return BadRequest(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var result = await Mediator.Send(new GetUsersQuery());
        if (result.Success)
        {

            return Ok(result);
        }
        return BadRequest(result.Message);
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete([FromForm] Guid id)
    {
        var result = await Mediator.Send(new DeleteUserCommand() {UserId = id});
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result.Message);
    }

}