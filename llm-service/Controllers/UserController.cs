using Backend.BusinessLogic.UserService;
using Backend.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        try
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user is null)
            {
                return NotFound("user not found");
            }

            return Ok(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");

            return StatusCode(
                500,
                "A server error occurred while processing the request."
            );
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(
        [FromBody] CreateUserDto createUserDto)
    {
        try
        {
            var user =
                await _userService.CreateUserAsync(createUserDto);

            return Ok(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");

            return StatusCode(
                500,
                "A server error occurred while processing the request."
            );
        }
    }

    [HttpPost("Login")]
    public async Task<ActionResult<LoginResponseDTO>> LoginUser(
        [FromBody] LoginDTO loginDto)
    {
        if (string.IsNullOrWhiteSpace(loginDto.Email) ||
            string.IsNullOrWhiteSpace(loginDto.Password))
        {
            return BadRequest("Email and password are required.");
        }

        try
        {
            var user = await _userService.LoginUserAsync(
                loginDto.Email,
                loginDto.Password
            );

            if (user is null)
            {
                return Unauthorized("Invalid email or password.");
            }

            return Ok(new LoginResponseDTO
            {
                Id = user.Id
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");

            return StatusCode(
                500,
                "A server error occurred while processing the request."
            );
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> ChangeUserInformation(
        int id, [FromBody] UpdateUserDto updatedUser)
    {
        try
        {
            var user = await _userService.UpdateUserInformationAsync(id, updatedUser);

            if (user is null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");

            return StatusCode(
                500,
                "A server error occurred while processing the request."
            );
        }
    }
}