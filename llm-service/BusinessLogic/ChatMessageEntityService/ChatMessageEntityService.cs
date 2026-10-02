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

    public ChatMessageEntityService(IChatMessageEnityRepository chatMessageEnityRepository, IClientO client)
    {
        _chatMessageEnityRepository = chatMessageEnityRepository;
        _client = client;
    }
    public async Task<ChatMessageEntityResponseDTO> CreateChatMessageEntity(int ChatID, string Content)
    {
        //create chat and appand chat message entity to the chat and save it to the database

        if (string.IsNullOrWhiteSpace(Content))
        {
            throw new ArgumentException("Message content cannot be empty.", nameof(Content));
        }

        ChatMessageEntity chatMessageEntity = new();
        chatMessageEntity.ChatId = ChatID;
        chatMessageEntity.Content = Content;
        chatMessageEntity.Role = "User";

        await _chatMessageEnityRepository.CreateChat(chatMessageEntity);
        String response = await _client.GetUserPromt(ChatID, Content);
        // oppdater den i databasen ()
        await _chatMessageEnityRepository.saveMessageEntityToDB(chatMessageEntity, response);


        return new ChatMessageEntityResponseDTO
        {
            Id = chatMessageEntity.Id,
            ChatId = ChatID,
            Content = Content,
            Response = response,

        };

    }

    public async Task<List<ChatMessageEntity>> GetChatMessages(int chatId)
    {
        List<ChatMessageEntity> messages = await _chatMessageEnityRepository.GetChatMessages(chatId);
        return messages;
    }


}
