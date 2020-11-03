using System.Diagnostics.CodeAnalysis;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VosakOrgWeb.Exceptions;
using VosakOrgWeb.Response;

namespace VosakOrgWeb.Controllers.Api.V1
{
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Login()
        {
            throw new VosakOrgWebException(HttpStatusCode.NotFound);
            return Ok(new ApiResponse(200, "OK", "done"));
        }
    }
}
