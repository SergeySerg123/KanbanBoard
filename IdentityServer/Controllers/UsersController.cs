using IdentityServer.DTO.User;
using IdentityServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ICollection<UserDTO>>> Get()
        {
            return Ok(await _userService.GetUsers());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDTO>> GetById(string id)
        {
            return Ok(await _userService.GetUserById(id));
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserDTO user)
        {
            await _userService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
