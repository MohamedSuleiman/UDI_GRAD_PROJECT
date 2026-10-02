using Microsoft.Extensions.AI;
using LlmService;

namespace LlmService;

public class OllamaClient : IClientO
{

    private IChatClient _chatClient;
    public OllamaClient(IChatClient chatClient)
    {
        _chatClient = chatClient;
    }

    public async Task<string> GetUserPromt(int chatId, string promt)
    {
        // var chat = await _db.Chats
        // .Include(c => c.Context)
        // .FirstOrDefaultAsync(c => c.Id == chatId);

        // if (chat is null)
        // throw new KeyNotFoundException($"Chat {chatId} was not found.");

        List<ChatMessage> messages = new();
        messages.Add(new(ChatRole.User, promt));


        string response = "";
        await foreach (var token in _chatClient.GetStreamingResponseAsync(messages))
        {
            response += token;
        }
        ;
        return response;
    }
}
