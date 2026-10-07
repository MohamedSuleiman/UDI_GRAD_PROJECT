using System.Security.Cryptography;
using Backend.DataAccessLayer.repositories;
using Backend.Domain.DTO;
using LlmService.Domain.Model;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;

namespace Backend.BusinessLogic.UserService;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _userRepository.GetUserByIdAsync(id);
    }

    public async Task<UserResponseDto> CreateUserAsync(CreateUserDto dto)
    {
        var existingEmail = await _userRepository.GetUserByEmailAsync(dto.Email);
        if (existingEmail != null)
        {
            throw new InvalidOperationException("User with this email already exists.");
        }

        var user = new User
        {

            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Nationality = dto.Nationality,
            UserUsage = dto.UserUsage

        };
        user.Password = _passwordHasher.HashPassword(user, dto.Password);
        await _userRepository.CreateUserAsync(user);

        var userResponse = new UserResponseDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email
        };
        return userResponse;
    }

    public async Task<User?> UpdateUserInformationAsync(int id, UpdateUserDto dto)
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

        await _userRepository.UpdateUserAsync(user);
        return user;
    }



    public async Task<User?> LoginUserAsync(string email, string password)
    {
        User? user = await _userRepository.GetUserByEmailAsync(email);

        if (user == null)
        {
            return null;
        }

        var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, password);

        if (verificationResult == PasswordVerificationResult.Failed)
        {
            return null;
        }

        return user;
    }

    public async Task<User?> DeleteUserAsync(int id)
    {
        User? user = await _userRepository.GetUserByIdAsync(id);

        if (user == null)
        {
            return null;
        }

        await _userRepository.DeleteUserAsync(user);

        return user;

    }

}
