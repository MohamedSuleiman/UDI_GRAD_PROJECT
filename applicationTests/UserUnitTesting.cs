using Backend.BusinessLogic.UserService;
using Backend.DataAccessLayer.repositories;
using Backend.Domain.DTO;
using LlmService.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace applicationTests;

public class UserUnitTesting
{
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


}