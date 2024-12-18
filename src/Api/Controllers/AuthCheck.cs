using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("auth")]
[Authorize]
public class AuthCheck : Controller
{

    public AuthCheck()
    {
    }

    [HttpGet("player")]
    public IActionResult PlayerAuthCheck()
    {
        return Ok("Pass");
    }

    [HttpGet("admin")]
    [Authorize(Roles= Roles.Admin)]
    public IActionResult AdminAuthCheck()
    {
        return Ok("Pass");
    }
    
    [HttpGet("brand")]
    [Authorize(Roles= Roles.Brand)]
    public IActionResult BrandAuthCheck()
    {
        return Ok("Pass");
    }
}