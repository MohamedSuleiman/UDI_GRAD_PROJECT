using System;
using LlmService.Domain.Enum;

namespace Backend.Domain.DTO;

public class UpdateUserDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public Nationality? Nationality { get; set; }
    public UserUsage? UserUsage { get; set; }

}
