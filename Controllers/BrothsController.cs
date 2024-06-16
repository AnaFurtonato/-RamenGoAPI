using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class BrothsController : ControllerBase
{
    private readonly List<Broth> _broths = new List<Broth>
    {
        new Broth { Id = "1", ImageInactive = "https://tech.redventures.com.br/icons/salt/inactive.svg", ImageActive = "https://tech.redventures.com.br/icons/salt/active.svg", Name = "Salt", Description = "Simple like the seawater, nothing more", Price = 10 },
       
    };

    [HttpGet]
    public IActionResult GetBroths([FromHeader(Name = "x-api-key")] string apiKey)
    {
        if (apiKey != "ZtVdh8XQ2U8pWI2gmZ7f796Vh8GllXoN7mr0djNf")
        {
            return StatusCode(403, new ErrorResponse { Error = "x-api-key header missing or invalid" });
        }
        
        return Ok(_broths);
    }
}
