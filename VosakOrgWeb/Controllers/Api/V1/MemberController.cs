using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VosakOrgServiceLayer;

namespace VosakOrg.Controllers.Api.V1
{
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("member")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IMemberService _memmberService;

        public MemberController(IMemberService memberService )
        {
            _memmberService = memberService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Login()
        {
            return Ok(_memmberService.GetAllMemeber());
        }
    }
}
