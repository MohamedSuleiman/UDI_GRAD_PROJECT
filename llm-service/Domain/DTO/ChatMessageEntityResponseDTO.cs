using System;

namespace Backend.Domain.DTO;

public class ChatMessageEntityResponseDTO
{
    public string Content {get; set;} = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
 
}
