using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VosakOrgServiceLayer;

namespace VosakOrgWeb.Controllers.Api.V1
{
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("member")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Login()
        {
            return Ok(_memberService.GetAllMemeber());
        }
    }
}
