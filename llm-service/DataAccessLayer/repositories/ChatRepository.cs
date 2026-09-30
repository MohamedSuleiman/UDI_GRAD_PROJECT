using System;
using LlmService.DataAccessLayer;

namespace Backend.DataAccessLayer.repositories;

public class ChatRepository : IChatRepository
{
    private readonly DataAccessContext _db;

    public ChatRepository(DataAccessContext db)
    {
        _db = db;
    }

}
