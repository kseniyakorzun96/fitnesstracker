using FitnessTrackerApp.Models;
using FitnessTrackerApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return new OkObjectResult(user);
        }
    }
}
