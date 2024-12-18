using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
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
