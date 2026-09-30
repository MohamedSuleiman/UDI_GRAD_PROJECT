using System;
using LlmService.DataAccessLayer;
using LlmService.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccessLayer.repositories;

public class ChatRepository : IChatRepository
{
    private readonly DataAccessContext _db;


    public ChatRepository(DataAccessContext db)
    {
        _db = db;
    }


    public async Task CreateChatAsync(Chat chat)
    {
        await _db.Chats.AddAsync(chat);
        await _db.SaveChangesAsync();
    }

    public async Task<Chat?> GetChatByIdAsync(int id)
    {
        return await _db.Chats.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Chat>> GetChatsByUserIdAsync(int userId)
    {
        return await _db.Chats
            .Where(c => c.UserId == userId)
            .ToListAsync();
    }
    
    public async Task<List<Chat>> GetAllChatsAsync()
    {
        return await _db.Chats.ToListAsync();
    }

    public async Task UpdateChatAsync(Chat chat)
    {
        await _db.SaveChangesAsync();
    }

    public async Task DeleteChatAsync(Chat chat)
    {
        _db.Chats.Remove(chat);
        await _db.SaveChangesAsync();
    }

}
