using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VosakOrg.Controllers.Api.V1
{
    [Route("auth")]
    [ApiVersion("1")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] object request)
        {
            return Ok(request);
        }
    }
}
