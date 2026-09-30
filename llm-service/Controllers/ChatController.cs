using Microsoft.AspNetCore.Mvc;
using LlmService.BusinessLogic;
using Backend.Domain.DTO;
namespace LlmService.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatController : ControllerBase
{
    private IClientO _client;
    private readonly ChatService _chatService;
    public ChatController(IClientO client, ChatService chatService)
    {
        _client = client;
        _chatService = chatService;
    }


    // [HttpPost]
    // public async Task<ActionResult> sendPrompt(ChatInputDTO chatInput)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return ValidationProblem(ModelState);
    //     }
    //     if (chatInput.Content == null || chatInput.Content.Length == 0)
    //     {
    //         return BadRequest(new ProblemDetails
    //         {
    //             Title = "Invalid Request",
    //             Detail = "Content cannot be empty",
    //             Status = StatusCodes.Status400BadRequest

    //         });
    //     }

    //     try
    //     {
    //         Console.WriteLine($"User Id: {chatInput.UserID}");

    //         string prompt = string.Join("\n", chatInput.Content);

    //         var response = await _client.GetUserPromt(chatInput.UserID, prompt);

    //         return Ok(response);
    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine($"Error: {ex.Message}");
    //         return StatusCode(500, "A server error occurred while processing the request.");
    //     }

    // }

    [HttpPost]
    public async Task<ActionResult> CreateChat(CreateChatDTO createChatDto)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        try
        {
            var chat = await _chatService.CreateChat(createChatDto);
            return Ok(chat);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new ProblemDetails
            {
                Title = "Invalid Request",
                Detail = ex.Message,
                Status = StatusCodes.Status400BadRequest
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return StatusCode(500, "A server error occurred while processing the request.");
        }
    }
}

