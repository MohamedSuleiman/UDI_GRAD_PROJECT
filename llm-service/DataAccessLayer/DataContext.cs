using System;
using Backend.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccessLayer;

public class DataAccessContext : DbContext
{
    private readonly string _connectionString; //"Host=localhost;Port=55432;Database= EquipmentManagementSystem;Username=postgres;Password=mypassword"


    public DataAccessContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {

        options.UseNpgsql(_connectionString);
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

}
