using System;
using LlmService.Domain.Model;


namespace Backend.DataAccessLayer.repositories;

public interface IChatRepository
{   
    Task CreateChatAsync(Chat chat);
    
    Task<Chat?> GetChatByIdAsync(int id);

    Task<List<Chat>> GetChatsByUserIdAsync(int userId);

    Task<List<Chat>> GetAllChatsAsync();

    Task UpdateChatAsync(Chat chat);

    Task DeleteChatAsync(Chat chat);
        
}
