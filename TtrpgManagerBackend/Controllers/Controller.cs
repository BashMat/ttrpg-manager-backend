using Microsoft.AspNetCore.Mvc;

namespace TtrpgManagerBacked.Controllers;

[ApiController]
[Route("[controller]")]
public class Controller : ControllerBase
{
    [HttpGet]
    public ActionResult Get()
    {
        return Ok();
    }
}