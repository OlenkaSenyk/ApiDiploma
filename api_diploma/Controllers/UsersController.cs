using api_diploma.Data.Services;
using api_diploma.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_diploma.Controllers
{
    [Route("users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersService _usersService;

        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_usersService.GetAllUsers());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_usersService.GetUserById(id));
        }
        /*
        [HttpPost]
        public IActionResult AddUser([FromBody] UserVM user)
        {
            _usersService.AddUser(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUserById(int id, [FromBody] UserVM user)
        {
            return Ok(_usersService.UpdateUserById(id, user));
        }
        */
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteUserById(int id)
        {
            _usersService.DeleteUserById(id);
            return Ok();
        }
    }
}
