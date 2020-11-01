using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VosakOrg.Controllers.V1
{
    [ApiVersion("1")]
    [Produces("application/json")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet]
        [Route("ping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Ping()
        {
            return Ok(new { message = "PONG", timestamp = DateTime.Now });
        }
    }
}
