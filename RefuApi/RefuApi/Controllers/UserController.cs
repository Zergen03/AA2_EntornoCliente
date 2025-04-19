using Microsoft.AspNetCore.Mvc;
using RefuApi.DTOs.Users;
using RefuApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

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
        //// GET: api/user
        //[HttpGet]
        //public IActionResult SearchUsers([FromQuery] string? name, [FromQuery] string? email)
        //{
        //    throw new NotImplementedException("SearchUsers method is not implemented yet.");
        //}


        // GET: api/user/{id}
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserDetails(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            var createdUser = await _userService.RegisterUser(createUserDTO);
            //return CreatedAtAction(nameof(GetUserById), new { id = 1 }, createdUser);
            return Ok();
        }
        // POST: api/user/login
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserDTO loginUserDTO)
        {
            var user = await _userService.LoginUser(loginUserDTO);
            if (user == null)
            {
                return Unauthorized();
            }
            var token = _userService.GenerateJWTToken(user);
            return Ok(new { token });
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
