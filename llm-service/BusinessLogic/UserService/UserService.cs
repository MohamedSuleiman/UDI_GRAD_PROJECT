using System;
using Backend.DataAccessLayer.repositories;
using Backend.Domain.DTO;
using LlmService.Domain.Model;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Backend.BusinessLogic.UserService;

//UserService is the Logic of what needs to happen
//befor the user reaches the database
//--
//All Methos in this class is related to User

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        User user = await _userRepository.GetUserByIdAsync(id);
        return user;
    }

    public async Task<User> CreateUserAsync(CreateUserDto dto)
    {
        var user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Nationality = dto.Nationality,
            UserUsage = dto.UserUsage


        };
        await _userRepository.CreateUserAsync(user);
        return user;
    }

    public async Task<User?> UpdateUserAsync(int id, UpdateUserDto dto)
    {
        User? user = await _userRepository.GetUserByIdAsync(id);

        if (user == null)
        {
            return null;
        }
        if (dto.FirstName != null)
        {
            user.FirstName = dto.FirstName;
        }
        if (dto.LastName != null)
        {
            user.LastName = dto.LastName;
        }
        if (dto.Nationality != null)
        {
            user.Nationality = dto.Nationality.Value;
        }
        if (dto.UserUsage != null)
        {
            user.UserUsage = dto.UserUsage.Value;
        }

        await _userRepository.UpdateUserAsync(user);
        return user;
    }


    // public async Task DeleteUser()

}
