using System;

namespace LlmService.BusinessLogic;

public class ChatService

{
   
    private readonly IClientO _client;

    public ChatService(IClientO client)
    {
        _client = client;
    }

    public async Task<string> SendPrompt(int userId, string input)
    {
        var response = await _client.GetUserPromt(userId, input);

        Console.WriteLine($"Response: {response}");

        return response;
    }


}
