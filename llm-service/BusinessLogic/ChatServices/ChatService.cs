using System;
using Backend.DataAccessLayer.repositories;
using Backend.Domain;
using Backend.Domain.DTO;
using LlmService.Domain;
using LlmService.Domain.Model;


namespace LlmService.BusinessLogic;

public class ChatService

{
    //test comment
    private readonly IClientO _client;
    private readonly IChatRepository _chatRepository;

    public ChatService(IClientO client, IChatRepository chatRepository)
    {
        _client = client;
        _chatRepository = chatRepository;

    }

    public async Task<string> SendPrompt(int userId, string input)
    {
        var response = await _client.GetUserPromt(userId, input);

        Console.WriteLine($"Response: {response}");

        return response;
    }


    public async Task<Chat> CreateChat(CreateChatDTO createChatDto)
    {
        //if chat content is empty delete the chat and return null
        //else create a new chat and return the chat object 
        if (string.IsNullOrWhiteSpace(createChatDto.Name))
        {
            throw new ArgumentException("Chat name cannot be empty.", nameof(createChatDto.Name));
        }

        if (createChatDto.UserId <= 0)
        {
            throw new ArgumentException("User ID must be a positive integer.", nameof(createChatDto.UserId));
        }

        var chat = new Chat
        {
            Name = createChatDto.Name,
            UserId = createChatDto.UserId,
            CreatedAt = DateTime.UtcNow,
        };

        await _chatRepository.CreateChatAsync(chat);
        return chat;
    }
    public async Task<Chat?> DeleteChat(int chatId)
    {
        var chat = await _chatRepository.GetChatByIdAsync(chatId);
        if (chat == null)
        {
            return null;
        }

        await _chatRepository.DeleteChatAsync(chat);
        return chat;
    }

}
