using Backend.DataAccessLayer.repositories;
using Backend.Domain.DTO;
using LlmService;
using LlmService.BusinessLogic;
using LlmService.Domain.Model;

using Moq;

namespace applicationTests;

public class IntegrationTest
{
    [Fact]
    public async Task CreateChat_ValidInput_ReturnsCreatedChat()
    {
        var mockClient = new Mock<IClientO>();
        var mockChatRepository = new Mock<IChatRepository>();
        mockChatRepository
            .Setup(repository => repository.CreateChatAsync(It.IsAny<Chat>()))
            .Returns(Task.CompletedTask);

        var chatService = new ChatService(mockClient.Object, mockChatRepository.Object);
        var createChatDto = new CreateChatDTO
        {
            Name = "Test Chat",
            UserId = 1
        };

        var result = await chatService.CreateChat(createChatDto);

        Assert.NotNull(result);
        Assert.Equal(createChatDto.Name, result.Name);
        Assert.Equal(createChatDto.UserId, result.UserId);
    }

    [Fact]
    public async Task CreateChat_InvalidInput_ThrowsArgumentException()
    {
        var mockClient = new Mock<IClientO>();
        var mockChatRepository = new Mock<IChatRepository>();
        var chatService = new ChatService(mockClient.Object, mockChatRepository.Object);
        var createChatDto = new CreateChatDTO
        {
            Name = "",
            UserId = 1
        };

        await Assert.ThrowsAsync<ArgumentException>(() => chatService.CreateChat(createChatDto));
    }

    [Fact]
    public async Task CreateChat_InvalidUserId_ThrowsArgumentException()
    {
        var mockClient = new Mock<IClientO>();
        var mockChatRepository = new Mock<IChatRepository>();
        var chatService = new ChatService(mockClient.Object, mockChatRepository.Object);
        var createChatDto = new CreateChatDTO
        {
            Name = "Test Chat",
            UserId = -1
        };

        await Assert.ThrowsAsync<ArgumentException>(() => chatService.CreateChat(createChatDto));
    }
}

