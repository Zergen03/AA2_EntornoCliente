using Microsoft.AspNetCore.Mvc;
using RefuApi.DTOs.Users;
using RefuApi.Services.Interfaces;

namespace RefuApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/user
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok("Get all users");
        }
        // GET: api/user/{id}
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok($"Get user with id {id}");
        }
        // POST: api/user
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            var createdUser = await _userService.RegisterUser(createUserDTO);
            //return CreatedAtAction(nameof(GetUserById), new { id = 1 }, createdUser);
            return Ok();
        }
        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] object user)
        {
            return NoContent();
        }
        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            return NoContent();
        }
    }
}
