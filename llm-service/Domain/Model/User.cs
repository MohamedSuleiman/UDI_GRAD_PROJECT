using System;
using System.ComponentModel.DataAnnotations;
using LlmService.Domain.Enum;

namespace LlmService.Domain.Model;

public class User
{

    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = "";
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = "";
    [Required]
    public string Email { get; set; } = "";
    [Required]
    public string Password { get; set; } = "";
    public Nationality Nationality { get; set; }
    public UserUsage UserUsage { get; set; }

    public List<Chat> Chats { get; set; } = new();



}
