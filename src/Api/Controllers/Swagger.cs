using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("")]
public class SwaggerRedirect : Controller
{

    public SwaggerRedirect()
    {
    }
    [HttpGet]
    public IActionResult Redirect()
    {
        return Redirect("/swagger/index.html");
    }
}
