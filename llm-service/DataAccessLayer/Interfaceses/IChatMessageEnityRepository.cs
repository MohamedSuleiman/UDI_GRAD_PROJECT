using System;
using LlmService.Domain.Model;

namespace Backend.DataAccessLayer.repositories;

public interface IChatMessageEnityRepository
{
    public Task CreateChat(ChatMessageEntity chatMessage);
}
