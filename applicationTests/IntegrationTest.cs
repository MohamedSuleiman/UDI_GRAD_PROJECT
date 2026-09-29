using LlmService;
using LlmService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace applicationTests;

public class IntegrationTest
{
    [Fact]
    public async Task Chat_SendPrompt_ReturnsOk()
    {
        // Arrange 
        var mockClient = new Mock<IClientO>();

        var controller = new ChatController(mockClient.Object);

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
        var mockClient = new Mock<IClientO>();
        var controller = new ChatController(mockClient.Object);

        var chatInput = new ChatInputDTO
        {
            UserID = 1,
            Content = []
        };

        // Act
        var result = await controller.sendPrompt(chatInput);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);

        Assert.Equal("Content cannot be empty.", badRequestResult.Value);
    }


    [Fact]
    public async Task Chat_SendNullContent_ReturnsError()
    {
        // Arrange 
        var mockClient = new Mock<IClientO>();
        var controller = new ChatController(mockClient.Object);

        var chatInput = new ChatInputDTO
        {
            UserID = 1,
            Content = null
        };

        // Act
        var result = await controller.sendPrompt(chatInput);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);

        Assert.Equal("Content cannot be empty.", badRequestResult.Value);
    }


    [Fact]
    public async Task Chat_SendMultiplePrompts_ReturnsOk()
    {
        // Arrange 
        var mockClient = new Mock<IClientO>();

        var controller = new ChatController(mockClient.Object);

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
}

