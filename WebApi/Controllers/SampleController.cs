using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SampleController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok("This is a protected endpoint");
    }
}
