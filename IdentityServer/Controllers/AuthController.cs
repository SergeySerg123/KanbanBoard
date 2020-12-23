using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly EmailService _emailService;

        public AuthController(AuthService authService, EmailService emailService)
        {
            _authService = authService;
            _emailService = emailService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthUserDTO>> Login(UserLoginDTO dto)
        {
            return Ok(await _authService.Authorize(dto));
        }

        [HttpGet("password/reset")]
        [AllowAnonymous]
        public async Task<ActionResult> Reset(string token)
        {
            var confirmToken = await _authService.Reset(token);
            var url = $"http://{Request.Host.Host + ":" + 4200}/profile?confirmToken={confirmToken}";
            return Redirect(url);
        }
    }
}