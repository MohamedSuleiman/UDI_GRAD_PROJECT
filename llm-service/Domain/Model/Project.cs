using System;
using Backend.Domain.Enum;

namespace Backend.Domain.Model;

public class Project
{
    public int Id { get; set; }

    public UserUsage WorkTheme { get; set; }

    public List<Chat> Chats { get; set; } = new();

}
