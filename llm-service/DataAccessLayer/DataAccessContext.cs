using System;
using LlmService.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace LlmService.DataAccessLayer;

public class DataAccessContext : DbContext
{


    public DataAccessContext(DbContextOptions<DataAccessContext> options)
       : base(options)
    {
    }

    


    public DbSet<Chat> Chats
    {
        get; set;
    }
    public DbSet<Project> Projects
    {
        get; set;
    }
    public DbSet<User> Users
    {
        get; set;
    }

    public DbSet<ChatMessageEntity> ChatMessageEntities
    {
        get; set;
    }

}
