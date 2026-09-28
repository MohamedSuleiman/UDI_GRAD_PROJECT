using Backend;
using Microsoft.Extensions.AI;
using OllamaSharp;

namespace LlmService;

public class OllamaClient : IOllamaClient
{
    // dependencyinject dette her;
    private OllamaApiClient _chatClient;
    //OllamaApiClient _chatClient;
    private Chat _chat;
    //IChatClient chatClient
    public OllamaClient()
    {
        _chatClient = new OllamaApiClient(new Uri("http://localhost:11434/"), "deepseek-r1:1.5b");
        _chat = new(_chatClient);
    }

    public async Task<string> GetUserPromt(string promt)
    {
        string response = "";
        await foreach (var token in _chat.SendAsync(promt))
        {
            response += token;
        }
        ;
        return response;
    }
}
