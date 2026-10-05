using System;
using LlmService.Domain.Enum;

namespace Backend.Domain.DTO;

public class CreateUserDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Nationality Nationality { get; set; }
    public UserUsage UserUsage { get; set; }

}
