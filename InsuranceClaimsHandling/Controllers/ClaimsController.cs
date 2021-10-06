using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceClaimsHandling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private IClaimsService _claimsService;
        public ClaimsController(IClaimsService claimsService)
        {
            _claimsService = claimsService;
        }

        [HttpGet("getAll")]
        [Authorize]
        public IActionResult getAll()
        {
            return Ok(_claimsService.GetAllClaims());
        }
    }
}
