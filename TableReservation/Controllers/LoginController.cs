using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace TableReservation.Controllers
{
    [ApiController]
    [Route("[controller]/v1")]
    public class LoginController : ControllerBase
    {
        private IAuthService authService;

        public LoginController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(LoginDto loginRequest)
        {
            return Ok(new TokenResponseDto() { Token = authService.Login(loginRequest) });
        }
    }
}
