using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;
using EntreEmpregos.Domain.Contracts;
using EntreEmpregos.Domain.Exceptions;
using EntreEmpregos.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntreEmpregos.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserLoginService _loginService;
    private readonly IUserService _service;

    public UserController(IUserService service, IUserLoginService loginService)
    {
        _service = service;
        _loginService = loginService;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
    {
        try
        {
            var result = await _loginService.AuthenticateAsync(request);
            return Ok(result);
        }
        catch (ValidationException exception)
        {
            return BadRequest(exception.Message);
        }
        catch (AuthenticationException exception)
        {
            return Unauthorized(exception.Message);
        }
        catch (Exception exception)
        {
#if DEBUG
            return StatusCode(500, exception.Message);
#endif
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserRequest request)
    {
        try
        {
            var result = await _service.AddAsync(request);
            return Created(nameof(Post), result);
        }
        catch (ValidationException exception)
        {
            return BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
#if DEBUG
            return StatusCode(500, exception.InnerException);
#endif
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
        catch (RecordNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch (Exception exception)
        {
#if DEBUG
            return StatusCode(500, exception.Message);
#endif
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        try
        {
            var result = await _service.GetAsync(id);
            return Ok(result);
        }
        catch (RecordNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch (Exception exception)
        {
#if DEBUG
            return StatusCode(500, exception.Message);
#endif
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id,
        [FromBody] UserRequest request)
    {
        try
        {
            var result = await _service.UpdateAsync(id, request);
            return Ok(result);
        }
        catch (ValidationException exception)
        {
            return BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
#if DEBUG
            return StatusCode(500, exception.Message);
#endif
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
        catch (RecordNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch (Exception exception)
        {
#if DEBUG
            return StatusCode(500, exception.Message);
#endif
            return StatusCode(500, "Internal Server Error");
        }
    }
}