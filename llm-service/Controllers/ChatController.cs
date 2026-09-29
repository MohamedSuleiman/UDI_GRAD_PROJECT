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
    
    string input = "What is the capital of Norway?";

    [HttpGet()]
    public async Task<ActionResult> sendPromt(string input)
    {
        var response = await _client.GetUserPromt(1, input);

        return Ok(response);
    }

    [HttpPost()]
    public async Task<ActionResult> sendPrompt(ChatInputDTO chatInput)
    {
        Console.WriteLine($"User Id: {chatInput.UserID}");

        foreach (string message in chatInput.Content)
        {
            Console.WriteLine(message);
        }

        var response = await _client.GetUserPromt(chatInput.UserID, chatInput.Content[0]);

        return Ok(response);
    }

}

