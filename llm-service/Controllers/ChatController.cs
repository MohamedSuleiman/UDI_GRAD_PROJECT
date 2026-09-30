using Microsoft.AspNetCore.Mvc;
using LlmService.BusinessLogic;
using Backend.BusinessLogic.ChatMessageEntityService;
using Backend.DataAccessLayer.repositories;
namespace LlmService.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatController : ControllerBase
{
    private ChatMessageEntityService _chatMessageEnityService;
    private IClientO _client;
    public ChatController(IClientO client, ChatMessageEntityService chatMessageEnityService)
    {
        _client = client;
        _chatMessageEnityService = chatMessageEnityService;
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

            var response = await _chatMessageEnityService.CreateChat(chatInput.UserID, prompt);

            return Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return StatusCode(500, "A server error occurred while processing the request.");
        }
   
    }

}

