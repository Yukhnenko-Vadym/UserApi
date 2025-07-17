using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TestTask.Data;
using TestTask.Exceptions;
using TestTask.Models;
using TestTask.Requests;
using TestTask.Service.Interface;

namespace TestTask.Controllers;

[ApiController]
[Route("api/v1")]
[ServiceFilter(typeof(ApiExceptionFilter))]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _usersService.GetUsers();
        return Ok(users);
    }

    [HttpPost("users")]
    public async Task<IActionResult> AddUser([FromBody] CreateUserRequest createUserRequest)
    {
        var user = await _usersService.CreateUser(createUserRequest);
        return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
    }

    [HttpDelete("users/{id}")]
    public async Task<IActionResult> DeleteUser([FromBody] int id)
    {
        var success = await _usersService.DeleteUser(id);
        if (!success)
            return NotFound(new { error = "User not found" });

        return NoContent();
    }
}