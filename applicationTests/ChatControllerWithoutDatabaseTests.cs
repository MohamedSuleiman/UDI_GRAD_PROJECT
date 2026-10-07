using Backend.BusinessLogic.ChatMessageEntityService;
using Backend.DataAccessLayer.repositories;
using Backend.Domain.DTO;
using LlmService;
using LlmService.BusinessLogic;
using LlmService.Controllers;
using LlmService.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;

// namespace applicationTests;

// public class ChatControllerWithoutDatabaseTests
// {
//     [Fact]
//     public async Task SendPrompt_UsesMockRepositoryAndClient()
//     {
//         var repository = new Mock<IChatMessageEnityRepository>();
//         repository
//             .Setup(repo => repo.CreateChat(It.IsAny<ChatMessageEntity>()))
//             .ReturnsAsync((ChatMessageEntity message) =>
//             {
//                 message.Id = 42;
//                 return message;
//             });

//         var client = new Mock<IClientO>();
//         client
//             .Setup(mock => mock.GetUserPromt(1, "Hello"))
//             .ReturnsAsync("Mock response");

        var chatRepository = new Mock<IChatRepository>();
        chatRepository
            .Setup(repo => repo.GetChatByIdAsync(1))
            .ReturnsAsync(new Chat { Id = 1, Name = "Test chat", UserId = 1 });
        repository
            .Setup(repo => repo.saveMessageEntityToDB(It.IsAny<ChatMessageEntity>(), "Mock response"))
            .Returns(Task.CompletedTask);

        var service = new ChatMessageEntityService(repository.Object, client.Object, chatRepository.Object);
        var chatService = new ChatService(client.Object, chatRepository.Object);
        var controller = new ChatController(client.Object, service, chatService);

        var result = await controller.sendPrompt(new ChatInputDTO
        {
            ChatID = 1,
            Content = ["Hello"]
        });

        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<ChatMessageEntityResponseDTO>(okResult.Value);
        Assert.Equal(42, response.Id);
        Assert.Equal("Mock response", response.Response);
        repository.Verify(repo => repo.CreateChat(It.Is<ChatMessageEntity>(message =>
            message.ChatId == 1 && message.Content == "Hello")), Times.Once);
        repository.Verify(repo => repo.saveMessageEntityToDB(
            It.IsAny<ChatMessageEntity>(), "Mock response"), Times.Once);
    }

    [Fact]
    public async Task SendPrompt_ReturnsBadRequest_WhenContentIsEmpty()
    {
        var repository = new Mock<IChatMessageEnityRepository>();
        var client = new Mock<IClientO>();
        var chatRepository = new Mock<IChatRepository>();
        var service = new ChatMessageEntityService(repository.Object, client.Object, chatRepository.Object);
        var chatService = new ChatService(client.Object, chatRepository.Object);
        var controller = new ChatController(client.Object, service, chatService);

//         var result = await controller.sendPrompt(new ChatInputDTO
//         {
//             ChatID = 1,
//             Content = []
//         });

//         var badRequest = Assert.IsType<BadRequestObjectResult>(result);
//         var problem = Assert.IsType<ProblemDetails>(badRequest.Value);
//         Assert.Equal("Content cannot be empty", problem.Detail);
//         repository.Verify(repo => repo.CreateChat(It.IsAny<ChatMessageEntity>()), Times.Never);
//         client.Verify(mock => mock.GetUserPromt(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
//     }

//     [Fact]
//     public async Task SendPrompt_JoinsContentLinesWithNewlines()
//     {
//         var repository = new Mock<IChatMessageEnityRepository>();
//         repository
//             .Setup(repo => repo.CreateChat(It.IsAny<ChatMessageEntity>()))
//             .ReturnsAsync((ChatMessageEntity message) => message);

//         var client = new Mock<IClientO>();
//         client
//             .Setup(mock => mock.GetUserPromt(1, "First line\nSecond line"))
//             .ReturnsAsync("Mock response");

        var chatRepository = new Mock<IChatRepository>();
        chatRepository
            .Setup(repo => repo.GetChatByIdAsync(1))
            .ReturnsAsync(new Chat { Id = 1, Name = "Test chat", UserId = 1 });
        repository
            .Setup(repo => repo.saveMessageEntityToDB(It.IsAny<ChatMessageEntity>(), "Mock response"))
            .Returns(Task.CompletedTask);

        var service = new ChatMessageEntityService(repository.Object, client.Object, chatRepository.Object);
        var chatService = new ChatService(client.Object, chatRepository.Object);
        var controller = new ChatController(client.Object, service, chatService);

        var result = await controller.sendPrompt(new ChatInputDTO
        {
            ChatID = 1,
            Content = ["First line", "Second line"]
        });

//         Assert.IsType<OkObjectResult>(result);
//         client.Verify(mock => mock.GetUserPromt(1, "First line\nSecond line"), Times.Once);
//         repository.Verify(repo => repo.CreateChat(It.Is<ChatMessageEntity>(message =>
//             message.ChatId == 1 && message.Content == "First line\nSecond line")), Times.Once);
//     }

//     [Fact]
//     public async Task SendPrompt_ReturnsServerError_WhenChatServiceThrows()
//     {
//         var repository = new Mock<IChatMessageEnityRepository>();
//         repository
//             .Setup(repo => repo.CreateChat(It.IsAny<ChatMessageEntity>()))
//             .ThrowsAsync(new InvalidOperationException("Database unavailable"));

        var client = new Mock<IClientO>();
        var chatRepository = new Mock<IChatRepository>();
        chatRepository
            .Setup(repo => repo.GetChatByIdAsync(1))
            .ReturnsAsync(new Chat { Id = 1, Name = "Test chat", UserId = 1 });
        var service = new ChatMessageEntityService(repository.Object, client.Object, chatRepository.Object);
        var chatService = new ChatService(client.Object, chatRepository.Object);
        var controller = new ChatController(client.Object, service, chatService);

        var result = await controller.sendPrompt(new ChatInputDTO
        {
            ChatID = 1,
            Content = ["Hello"]
        });

//         var serverError = Assert.IsType<ObjectResult>(result);
//         Assert.Equal(500, serverError.StatusCode);
//         Assert.Equal("A server error occurred while processing the request.", serverError.Value);
//         client.Verify(mock => mock.GetUserPromt(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
//     }
// }