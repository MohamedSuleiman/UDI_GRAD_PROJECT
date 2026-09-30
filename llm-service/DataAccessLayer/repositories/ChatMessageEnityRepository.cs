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

    public Task<ChatMessageEntityResponseDTO> CreateChat(int ChatID, string Content)
    {
        throw new NotImplementedException();
    }
}
    