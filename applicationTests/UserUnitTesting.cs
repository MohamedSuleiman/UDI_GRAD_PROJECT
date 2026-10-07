using Backend.BusinessLogic.UserService;
using Backend.DataAccessLayer.repositories;
using Backend.Domain.DTO;
using LlmService.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace applicationTests;

public class UserUnitTesting
{
    // Test for creating a user
    [Fact]
    public async Task CreateUser_ValidInput()
    {
        // Arrange
        var repository = new Mock<IUserRepository>();
        var hasher = new Mock<IPasswordHasher<User>>();

        var dto = new CreateUserDto
        {
            FirstName = "Kar",
            LastName = "traa",
            Email = "kari.traa@example.com",
            Password = "TestPassword123!"
        };

        repository
            .Setup(r => r.GetUserByEmailAsync(dto.Email))
            .ReturnsAsync((User?)null);

        hasher
            .Setup(h => h.HashPassword(It.IsAny<User>(), dto.Password))
            .Returns("hashed-password");

        User? savedUser = null;

        repository
            .Setup(r => r.CreateUserAsync(It.IsAny<User>()))
            .Callback<User>(u =>
            {
                u.Id = 1;
                savedUser = u;
            })
            .Returns(Task.CompletedTask);

        var service = new UserService(repository.Object, hasher.Object);

        // Act
        var response = await service.CreateUserAsync(dto);

        // Assert: response DTO mapping
        Assert.Equal(1, response.Id);
        Assert.Equal(dto.FirstName, response.FirstName);
        Assert.Equal(dto.LastName, response.LastName);
        Assert.Equal(dto.Email, response.Email);

        // Assert: entity sent to the repository
        Assert.NotNull(savedUser);
        Assert.Equal(dto.FirstName, savedUser.FirstName);
        Assert.Equal(dto.LastName, savedUser.LastName);
        Assert.Equal(dto.Email, savedUser.Email);
        Assert.Equal("hashed-password", savedUser.Password);

        repository.Verify(
            r => r.CreateUserAsync(It.IsAny<User>()),
            Times.Once);

        hasher.Verify(
            h => h.HashPassword(savedUser, dto.Password),
            Times.Once);
    }


    [Fact]

    public async Task CreateUser_DuplicateEmail_throwsExeption()

    {
        //Arrange 

        var repository = new Mock<IUserRepository>();
        var hasher = new Mock<IPasswordHasher<User>>();

        var dto = new CreateUserDto
        {
            FirstName = "Kar",
            LastName = "traa",
            Email = "kari.traa@example.com",
            Password = "TestPassword123!"
        };

        repository
            .Setup(r => r.GetUserByEmailAsync(dto.Email))
            .ReturnsAsync(new User());

        var service = new UserService(repository.Object, hasher.Object);

        //Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(async () => await service.CreateUserAsync(dto));
    }


    //Update user information test
    [Fact]
    public async Task UpdateUserInformation_ValidInput()
    {
        // Arrange
        var repository = new Mock<IUserRepository>();
        var hasher = new Mock<IPasswordHasher<User>>();

        var existingUser = new User
        {
            Id = 1,
            FirstName = "OldFirstName",
            LastName = "OldLastName",
            Email = "old.user@example.com"
        };

        var updatedUserDto = new UpdateUserDto
        {
            FirstName = "NewFirstName",
            LastName = "NewLastName"
        };

        repository
            .Setup(r => r.GetUserByIdAsync(existingUser.Id))
            .ReturnsAsync(existingUser);

        repository
            .Setup(r => r.UpdateUserAsync(It.IsAny<User>()))
            .Returns(Task.CompletedTask);

        var service = new UserService(repository.Object, hasher.Object);

        // Act
        await service.UpdateUserInformationAsync(existingUser.Id, updatedUserDto);

        // Assert
        repository.Verify(r => r.UpdateUserAsync(It.Is<User>(u => u.Id == existingUser.Id)), Times.Once);
    }


    [Fact]
    public async Task UpdateUserInformation_UserNotFound_ReturnsNull()
    {
        // Arrange
        var repository = new Mock<IUserRepository>();
        var hasher = new Mock<IPasswordHasher<User>>();

        repository
            .Setup(r => r.GetUserByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((User?)null);

        var service = new UserService(repository.Object, hasher.Object);

        // Act
        var result = await service.UpdateUserInformationAsync(999, new UpdateUserDto());

        // Assert
        Assert.Null(result);
    }

    //Login user test
    [Fact]
    public async Task LoginUser_Valid_ReturnsUser()
    {
        // Arrange
        var repository = new Mock<IUserRepository>();
        var hasher = new Mock<IPasswordHasher<User>>();

        var existingUser = new User
        {
            Id = 1,
            FirstName = "Test",
            LastName = "User",
            Email = "test.user@example.com",
            Password = "HashedPassword123!"
        };

        repository
            .Setup(r => r.GetUserByEmailAsync(existingUser.Email))
            .ReturnsAsync(existingUser);

        hasher
            .Setup(h => h.VerifyHashedPassword(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()))
            .Returns(PasswordVerificationResult.Success);

        var service = new UserService(repository.Object, hasher.Object);

        // Act
        var result = await service.LoginUserAsync(existingUser.Email, "TestPassword123!");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(existingUser.Id, result.Id);
    }
}