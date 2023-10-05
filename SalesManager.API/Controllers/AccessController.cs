using DataTransferObjects.Utils;
using Microsoft.AspNetCore.Mvc;
using SalesManager.API.Interfaces;

namespace SalesManager.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccessController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<bool>> Login([FromBody] LoginFormPostDTO loginFormPostDTO) => await _userService.CheckAccess(loginFormPostDTO);
    }
}
