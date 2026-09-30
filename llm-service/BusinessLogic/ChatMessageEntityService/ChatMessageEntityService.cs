using System;
using Backend.DataAccessLayer.repositories;
using Backend.Domain.DTO;
using LlmService;
using LlmService.Domain.Model;

namespace Backend.BusinessLogic.ChatMessageEntityService;

public class ChatMessageEntityService
{
    private IChatMessageEnityRepository _chatMessageEnityRepository;
    private IClientO _client; 

    // Husk Å dependency injecte dette her;
    public ChatMessageEntityService (IChatMessageEnityRepository chatMessageEnityRepository, IClientO client) {
        _chatMessageEnityRepository = chatMessageEnityRepository;
        _client = client;
    }
    public async Task CreateChat(int ChatID, string Content) 
    {

       if (string.IsNullOrWhiteSpace(Content))
        {
            throw new ArgumentException("Message content cannot be empty.", nameof(Content));
        }

        ChatMessageEntity chatMessageEntity = new ();
        chatMessageEntity.ChatId = ChatID;
        chatMessageEntity.Content = Content;
        chatMessageEntity.Role = "User";
        ChatMessageEntity response = await _chatMessageEnityRepository.CreateChat(chatMessageEntity);
        await _client.GetUserPromt(ChatID, Content);
       // return new ChatMessageEntityResponseDTO
       // {
            
       // };

    }


}
