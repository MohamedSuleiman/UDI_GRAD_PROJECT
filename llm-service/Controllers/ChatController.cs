using Microsoft.AspNetCore.Mvc;

namespace LlmService.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatController : ControllerBase
{
    private ChatM _c;
    public ChatController()
    {
     _c = new();   
    }
    [HttpGet()]
    public async Task<ActionResult> sendPromt()
    {
        var response = await _c.getUserPromt("Whats the capital of norway");
        return Ok(response);
    }
}
