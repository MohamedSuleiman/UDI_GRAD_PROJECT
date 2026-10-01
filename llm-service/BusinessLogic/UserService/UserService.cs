using System;
using System.Security.Cryptography;
using Backend.DataAccessLayer.repositories;
using Backend.Domain.DTO;
using LlmService.Domain.Model;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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
            Email = dto.Email,
            Password = dto.Password,
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
        if (dto.Email != null)
        {
            user.Email = dto.Email;
        }
        if (dto.Password != null)
        {
            user.Password = dto.Password;
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


    public async Task<User?> DeleteUserAsync(int id)
    {
        User user = await _userRepository.GetUserByIdAsync(id);

        if (user == null)
        {
            return null;
        }

        await _userRepository.DeleteUserAsync(user);

        return user;

    }

/*
// Missing storing of hashing and salt to finish the implementation of this method.
    public async Task<User?> HashPasswordAsync(int id, string password)
    {
        User user = await _userRepository.GetUserByIdAsync(id);

        if (user == null)
        {
            return null;
        }

        // Generate a 128-bit salt using a sequence of
        // cryptographically strong random bytes.
        byte[] salt = RandomNumberGenerator.GetBytes(128/8); // Generate a random salt

        // deriving a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
        string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));   

        user.Password = hashedPassword;

        await _userRepository.UpdateUserAsync(user);

        return user;
    }

*/
}
