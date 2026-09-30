using System;
using Microsoft.Net.Http.Headers;

namespace Backend.Domain.DTO;

public class ChatMessageEntityResponseDTO
{
    public int Id  {get; set;}
    public string Content {get; set;} = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
 
}
