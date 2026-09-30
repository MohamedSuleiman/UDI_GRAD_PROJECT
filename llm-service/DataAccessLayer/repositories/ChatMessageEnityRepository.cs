using System;
using LlmService.DataAccessLayer;
using LlmService.Domain.Model;
using Microsoft.EntityFrameworkCore;


namespace Backend.DataAccessLayer.repositories;

public class ChatMessageEnityRepository : IChatMessageEnityRepository
{
    private readonly DataAccessContext _db;

    public ChatMessageEnityRepository(DataAccessContext db)
    {
        _db = db;
    }

    public async Task CreateChat(ChatMessageEntity chatMessage)
    {
        _db.ChatMessageEntities.Add(chatMessage);
        await _db.SaveChangesAsync();
    }



}
    