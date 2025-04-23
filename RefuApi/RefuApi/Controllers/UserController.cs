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
        public async Task<IActionResult> SearchUsers([FromQuery] string? name, [FromQuery] string? email, [FromQuery] bool? isVeteran)
        {
            var userQueryParametersDTO = new UserQueryParametersDTO
            {
                Name = name,
                Email = email
            };

            var users = await _userService.GetAllUsers(userQueryParametersDTO);

            return Ok(users);
        }

        // GET: api/user/{id}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var userDto = await _userService.GetUserDetails(id);
                if (userDto == null)
                {
                    return NotFound();
                }

                return Ok(userDto);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", details = ex.Message });
            }
        }

        // POST: api/user
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            var createdUser = await _userService.RegisterUser(createUserDTO);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
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
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDTO userDTO)
        {
            try
            {
                var user = await _userService.UpdateUserDetails(id, userDTO);
                return Ok(user);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = $"Unexpected error occurred: {ex.Message}" });
            }
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return NoContent(); 
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new {message = ex.Message});
            }
            catch(Exception ex)
            {
                return StatusCode(500, new {message = ex.Message});
            }
        }
    }
}
