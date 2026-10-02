using System;
using Backend.Domain.DTO;
using LlmService.Domain.Model;

namespace Backend.DataAccessLayer.repositories;

public interface IChatMessageEnityRepository
{
    public Task<ChatMessageEntity> CreateChat(ChatMessageEntity chatMessage);
    public Task saveMessageEntityToDB(ChatMessageEntity chatMessageEntity, string response);
    public  Task<ChatMessageEntityResponseDTO> CreateChat(int ChatId, string Content);
    public Task<List<ChatMessageEntity>> getAllChats(int ChatId);
}
