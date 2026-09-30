using Backend.BusinessLogic.ChatMessageEntityService;
using Backend.DataAccessLayer.repositories;
using Backend.Domain.DTO;
using LlmService;
using LlmService.Controllers;
using LlmService.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace applicationTests;

public class ChatControllerWithoutDatabaseTests
{
    [Fact]
    public async Task SendPrompt_UsesMockRepositoryAndClient()
    {
        var repository = new Mock<IChatMessageEnityRepository>();
        repository
            .Setup(repo => repo.CreateChat(It.IsAny<ChatMessageEntity>()))
            .ReturnsAsync((ChatMessageEntity message) =>
            {
                message.Id = 42;
                return message;
            });

        var client = new Mock<IClientO>();
        client
            .Setup(mock => mock.GetUserPromt(1, "Hello"))
            .ReturnsAsync("Mock response");

        var service = new ChatMessageEntityService(repository.Object, client.Object);
        var controller = new ChatController(client.Object, service);

        var result = await controller.sendPrompt(new ChatInputDTO
        {
            UserID = 1,
            Content = ["Hello"]
        });

        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<ChatMessageEntityResponseDTO>(okResult.Value);
        Assert.Equal(42, response.Id);
        Assert.Equal("Mock response", response.response);
        repository.Verify(repo => repo.CreateChat(It.Is<ChatMessageEntity>(message =>
            message.ChatId == 1 && message.Content == "Hello")), Times.Once);
    }
}