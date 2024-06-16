using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProteinsController : ControllerBase
{
    private readonly List<Protein> _proteins = new List<Protein>
    {
        new Protein { Id = "1", ImageInactive = "https://tech.redventures.com.br/icons/pork/inactive.svg", ImageActive = "https://tech.redventures.com.br/icons/pork/active.svg", Name = "Chasu", Description = "A sliced flavourful pork meat with a selection of season vegetables.", Price = 10 },
        
    };

    [HttpGet]
    public IActionResult GetProteins([FromHeader(Name = "x-api-key")] string apiKey)
    {
        if (apiKey != "ZtVdh8XQ2U8pWI2gmZ7f796Vh8GllXoN7mr0djNf")
        {
            return StatusCode(StatusCodes.Status403Forbidden, new ErrorResponse { Error = "x-api-key header missing or invalid" });
        }
        return Ok(_proteins);
    }
}
