using System;
using LlmService.Domain.Enum;

namespace LlmService.Domain.Model;

public class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";

    public Nationality Nationality { get; set; }
    public UserUsage UserUsage { get; set; }

    public List<Chat> Chats { get; set; } = new();

}
