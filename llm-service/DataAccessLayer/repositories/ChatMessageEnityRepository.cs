using System;
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





}
    