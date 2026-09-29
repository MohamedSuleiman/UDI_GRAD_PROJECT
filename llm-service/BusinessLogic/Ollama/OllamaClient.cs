using LlmService;
using Microsoft.Extensions.AI;
using OllamaSharp;

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
            //egt flow, hent chat fra db
        // -- Chat chat = db.getChat(id)
        // -- List<ChatMessage> messages = chat.context;
        // messages.add(promt)
        // pass inn context til GetStreamingResponseAsync()
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
