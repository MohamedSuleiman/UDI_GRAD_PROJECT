

namespace LlmService.Domain.Model;

public class Chat
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public List<ChatMessageEntity> Context { get; set; } = new();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int? ProjectId { get; set; }
    public Project? Project { get; set; }
}
