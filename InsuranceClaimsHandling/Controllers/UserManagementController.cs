using InsuranceClaimsHandling.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceClaimsHandling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private IAuthenticationService _authenticationService;

        public UserManagementController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            var token = _authenticationService.Authentication(loginModel.UserName, loginModel.Password);
            
            if (token == null)
                return Unauthorized();
            
            return Ok(token);
        }
    }
}
