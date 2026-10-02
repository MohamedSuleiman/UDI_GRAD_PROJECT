using Microsoft.AspNetCore.Mvc;
using LlmService.BusinessLogic;
using Backend.BusinessLogic.ChatMessageEntityService;
using Backend.DataAccessLayer.repositories;
using Backend.Domain.DTO;
namespace LlmService.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatController : ControllerBase
{
    private ChatMessageEntityService _chatMessageEnityService;
    private IClientO _client;
    private ChatService _chatService;

    public ChatController(IClientO client, ChatMessageEntityService chatMessageEnityService, ChatService chatService)
    {
        _client = client;
        _chatMessageEnityService = chatMessageEnityService;
        _chatService = chatService;
    }


    [HttpPost]
    public async Task<ActionResult> sendPrompt(ChatInputDTO chatInput)
    {

        if (chatInput.Content == null || chatInput.Content.Length == 0)
        {
            return BadRequest(new ProblemDetails
            {
                Title = "Invalid Request",
                Detail = "Content cannot be empty",
                Status = StatusCodes.Status400BadRequest

            });
        }

        try
        {
            Console.WriteLine($"User Id: {chatInput.ChatID}");

            string prompt = string.Join("\n", chatInput.Content);

            ChatMessageEntityResponseDTO response = await _chatMessageEnityService.CreateChatMessageEntity(chatInput.ChatID, prompt);

            return Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return StatusCode(500, "A server error occurred while processing the request.");
        }

    }


    [HttpPost]
    [Route("create")]
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

