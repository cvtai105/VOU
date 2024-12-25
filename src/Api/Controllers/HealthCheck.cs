using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("health")]
public class HealthCheck : Controller
{

    public HealthCheck()
    {
    }
    [HttpGet]
    public IActionResult GetHealthStatus()
    {
        return Ok("Healthy");
    }
}
