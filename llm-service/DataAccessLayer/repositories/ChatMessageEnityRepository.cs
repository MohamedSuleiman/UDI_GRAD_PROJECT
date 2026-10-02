using System;
using Backend.Domain.DTO;
using LlmService.DataAccessLayer;
using LlmService.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.AI;


namespace Backend.DataAccessLayer.repositories;

public class ChatMessageEnityRepository : IChatMessageEnityRepository
{
    private readonly DataAccessContext _db;

    public ChatMessageEnityRepository(DataAccessContext db)
    {
        _db = db;
    }

    public async Task<ChatMessageEntity> CreateChat(ChatMessageEntity chatMessage)
    {
        _db.ChatMessageEntities.Add(chatMessage);
        await _db.SaveChangesAsync();
        return chatMessage;
    }

    public async Task saveMessageEntityToDB(ChatMessageEntity chatMessageEntity, string response) 
    {
         chatMessageEntity.Response = response;
        _db.Update(chatMessageEntity);
        await _db.SaveChangesAsync();
    }

    public Task<ChatMessageEntityResponseDTO> CreateChat(int ChatID, string Content)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ChatMessageEntity>> GetChatMessages(int ChatId)
    {
        List<ChatMessageEntity> listOfChatsForGivenChatID = await _db.ChatMessageEntities.
        Where(msg => msg.ChatId == ChatId).ToListAsync();
        return listOfChatsForGivenChatID;
    }
}
    