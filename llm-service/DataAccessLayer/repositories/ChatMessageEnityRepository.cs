using System;
using LlmService.DataAccessLayer;

namespace Backend.DataAccessLayer.repositories;

public class ChatMessageEnityRepository : IChatMessageEnityRepository
{
    private readonly DataAccessContext _db;

    public ChatMessageEnityRepository(DataAccessContext db)
    {
        _db = db;
    }
}
