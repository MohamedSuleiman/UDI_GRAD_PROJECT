using System;
using Microsoft.Net.Http.Headers;

namespace Backend.Domain.DTO;

public class ChatMessageEntityResponseDTO
{
    public int Id  {get; set;}

    public int ChatId {get; set;}
    public string promt {get; set;} = string.Empty;
    public string response {get; set;} = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
 
}
