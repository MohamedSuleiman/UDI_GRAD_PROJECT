using Backend.BusinessLogic.ChatMessageEntityService;
using Backend.DataAccessLayer.repositories;
using LlmService;
using LlmService.BusinessLogic;
using LlmService.Controllers;
using LlmService.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace applicationTests;

public class IntegrationTest
{
    private static ChatController CreateController()
    {
        var mockClient = new Mock<IClientO>();
        mockClient
            .Setup(client => client.GetUserPromt(It.IsAny<int>(), It.IsAny<string>()))
            .ReturnsAsync("Mock response");

        var mockRepository = new Mock<IChatMessageEnityRepository>();
        mockRepository
            .Setup(repository => repository.CreateChat(It.IsAny<ChatMessageEntity>()))
            .ReturnsAsync((ChatMessageEntity message) => message);

        var service = new ChatMessageEntityService(mockRepository.Object, mockClient.Object);
        return new ChatController(mockClient.Object, service);
    }

    [Fact]
    public async Task Chat_SendPrompt_ReturnsOk()
    {
        // Arrange 
        var controller = CreateController();

        var chatInput = new ChatInputDTO
        {
            UserID = 1,
            Content = ["Hello, how are you?"]
        };

        // Act
        var result = await controller.sendPrompt(chatInput);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Chat_SendEmptyPrompt_ReturnsError()
    {
        // Arrange 
        var controller = CreateController();

        var chatInput = new ChatInputDTO
        {
            UserID = 1,
            Content = []
        };

        // Act
        var result = await controller.sendPrompt(chatInput);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);

        var problem = Assert.IsType<ProblemDetails>(badRequestResult.Value);
        Assert.Equal("Content cannot be empty", problem.Detail);
    }


    [Fact]
    public async Task Chat_SendNullContent_ReturnsError()
    {
        // Arrange 
        var controller = CreateController();

        var chatInput = new ChatInputDTO
        {
            UserID = 1,
            Content = null!
        };

        // Act
        var result = await controller.sendPrompt(chatInput);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);

        var problem = Assert.IsType<ProblemDetails>(badRequestResult.Value);
        Assert.Equal("Content cannot be empty", problem.Detail);
    }


    [Fact]
    public async Task Chat_SendMultiplePrompts_ReturnsOk()
    {
        // Arrange 
        var controller = CreateController();

        var chatInput = new ChatInputDTO
        {
            UserID = 1,
            Content = ["Hello, how are you?", "I'm doing well, thank you!"]
        };

        // Act
        var result = await controller.sendPrompt(chatInput);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
    */
    [Fact]
    public async Task CreateChat_ValidInput_ReturnsCreatedChat()
    {
        // Arrange
        var mockClient = new Mock<IClientO>();
        var mockChatRepository = new Mock<IChatRepository>();

        var chatService = new ChatService(mockClient.Object, mockChatRepository.Object);

        var createChatDto = new CreateChatDTO
        {
            Name = "Test Chat",
            UserId = 1
        };

        // Act
        var result = await chatService.CreateChat(createChatDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(createChatDto.Name, result.Name);
        Assert.Equal(createChatDto.UserId, result.UserId);
    }

    [Fact]
    public async Task CreateChat_InvalidInput_ThrowsArgumentException()
    {
        // Arrange
        var mockClient = new Mock<IClientO>();
        var mockChatRepository = new Mock<IChatRepository>();

        var chatService = new ChatService(mockClient.Object, mockChatRepository.Object);

        var createChatDto = new CreateChatDTO
        {
            Name = "", // Invalid name
            UserId = 1
        };

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => chatService.CreateChat(createChatDto));
    }

    [Fact]
    public async Task CreateChat_InvalidUserId_ThrowsArgumentException()
    {
        // Arrange
        var mockClient = new Mock<IClientO>();
        var mockChatRepository = new Mock<IChatRepository>();

        var chatService = new ChatService(mockClient.Object, mockChatRepository.Object);

        var createChatDto = new CreateChatDTO
        {
            Name = "Test Chat",
            UserId = -1 // Invalid user ID
        };

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => chatService.CreateChat(createChatDto));
    }

}

