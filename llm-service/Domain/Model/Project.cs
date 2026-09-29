using System;
using LlmService.Domain.Enum;

namespace LlmService.Domain.Model;

public class Project
{
    public int Id { get; set; }

    public UserUsage WorkTheme { get; set; }

    public List<Chat> Chats { get; set; } = new();

}
