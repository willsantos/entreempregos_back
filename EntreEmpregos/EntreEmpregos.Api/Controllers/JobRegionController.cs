using System.ComponentModel.DataAnnotations;
using EntreEmpregos.Domain.Contracts;
using EntreEmpregos.Domain.Exceptions;
using EntreEmpregos.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntreEmpregos.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class JobRegionController: ControllerBase
{
    private readonly IJobRegionService _service;

    public JobRegionController(IJobRegionService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] JobRegionRequest request)
    {
        try
        {
            var result = await _service.AddAsync(request);
            return Created(nameof(Post), result);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
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
        catch (RecordNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
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
        catch (RecordNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] JobRegionRequest request)
    {
        try
        {
            var result = await _service.UpdateAsync(id, request);
            return Ok(result);
        }
        catch (RecordNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
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
        catch (RecordNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }
}