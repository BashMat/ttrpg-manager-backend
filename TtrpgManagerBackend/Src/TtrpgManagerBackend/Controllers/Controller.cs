using Microsoft.AspNetCore.Mvc;

namespace TtrpgManagerBackend.Controllers;

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