using System;
using Backend.Domain.DTO;
using LlmService.Domain.Model;

namespace Backend.BusinessLogic.UserService;

public interface IUserService
{
    Task<User> CreateUserAsync(CreateUserDto dto);
    Task<User?> UpdateUserInformationAsync(int id, UpdateUserDto dto);

    Task<User?> GetUserByIdAsync(int id);

    Task<User?> LoginUserAsync(string email, string password);


}
