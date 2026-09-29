using Microsoft.AspNetCore.Mvc;
using LlmService.BusinessLogic;
namespace LlmService.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatController : ControllerBase
{
    private IClientO _client;
    public ChatController(IClientO client)
    {
        _client = client;
    }
    

    [HttpPost()]
    public async Task<ActionResult> sendPrompt(ChatInputDTO chatInput)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }
        if (chatInput.Content == null || chatInput.Content.Length == 0)
            {
                return BadRequest(new ProblemDetails{
                    Title = "Invalid Request",
                    Detail = "Content cannot be empty",
                    Status = StatusCodes.Status400BadRequest

                });
            }

        try {
            Console.WriteLine($"User Id: {chatInput.UserID}");

            string prompt = string.Join("\n", chatInput.Content);

            var response = await _client.GetUserPromt(chatInput.UserID, prompt);

            return Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return StatusCode(500, "A server error occurred while processing the request.");
        }
   
    }

}

