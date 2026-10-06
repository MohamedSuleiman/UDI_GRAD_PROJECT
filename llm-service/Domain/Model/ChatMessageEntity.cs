using System;
namespace LlmService.Domain.Model;

public class ChatMessageEntity
{
    public int Id { get; set; }
<<<<<<< HEAD
=======

>>>>>>> 391d3e64d51955d5228e5df4508a0fa1e90ff88b
    public int ChatId { get; set; }
    public Chat Chat { get; set; } = null!;

    public string Role { get; set; } = "";
    public string Content { get; set; } = "";

    public string Response { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}
