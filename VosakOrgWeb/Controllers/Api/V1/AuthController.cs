using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VosakOrg.Controllers.Api.V1
{
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Login([FromBody] object request)
        {
            return Ok(request);
        }
    }
}
