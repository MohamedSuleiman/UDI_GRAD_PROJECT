using System;
using LlmService.Domain.Model;
using Microsoft.AspNetCore.SignalR;

namespace Backend.DataAccessLayer.repositories;

public interface IUserRepository
{

    Task<User>? GetUserByIdAsync(int id);

    Task CreateUserAsync(User user);

    Task UpdateUserAsync(User user);

    //IMPLIMENT THIS 
    Task DeleteUserAsync(User user);
}
