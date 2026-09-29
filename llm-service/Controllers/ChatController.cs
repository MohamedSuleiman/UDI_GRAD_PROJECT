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
    [HttpGet()]
    public async Task<ActionResult> sendPromt()
    {
        var response = await _client.GetUserPromt(1, "Whats the capital of norway");

        return Ok(response);
    }

}

