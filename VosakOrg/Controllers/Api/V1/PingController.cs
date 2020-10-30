using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VosakOrg.Controllers.V1
{
    [ApiVersion("1")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet]
        [Route("ping")]
        public IActionResult Ping()
        {
            return Ok(new { message = "PONG", timestamp = DateTime.Now });
        }
    }
}
