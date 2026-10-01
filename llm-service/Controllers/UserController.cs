using System.Linq.Expressions;
using Backend.BusinessLogic.UserService;
using Backend.Domain.DTO;
using LlmService.Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Controllers

// sins we are using Attribute [ApiController] ASP.NET automaticly checks
//  for ModelValidation befor reaching Controller class. 
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]

        public IActionResult RootMethod()
        {
            Console.WriteLine("test");

            return Ok("test");
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            // if (!ModelState.IsValid)
            // {
            //     return ValidationProblem(ModelState);
            // }

            try
            {
                var user = await _userService.GetUserByIdAsync(id);

                if (user is null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception e)
            {

                Console.WriteLine($"Error: {e.Message}");
                return NotFound("Cant find user");

            }


        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            // if (!ModelState.IsValid)
            // {
            //     return ValidationProblem(ModelState);
            // }

            try
            {
                var user = await _userService.CreateUserAsync(createUserDto);
                return Ok(user);

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return StatusCode(500, "A server error occurred while processing the request.");
            }

        }

    }
}


