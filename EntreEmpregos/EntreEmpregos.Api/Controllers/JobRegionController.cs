using EntreEmpregos.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EntreEmpregos.Controllers;

[ApiController]
[Route("[controller]")]
public class JobRegionController
{
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] JobRegionRequest)
    {
        try
        {
            var result = await _
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest("Falha ao cadastrar");
        }
        
        
    }
}