using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace VosakOrg.Controllers
{
    [Route("/")]
    public class WelcomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Content(
                System.IO.File.ReadAllText("Static/WelcomePage.html"),
                "text/html",
                System.Text.Encoding.UTF8
                );
        }
    }
}
