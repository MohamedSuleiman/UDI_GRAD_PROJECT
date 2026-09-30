using System;
using LlmService.Domain.Enum;

namespace Backend.Domain.DTO;

public class CreateUserDto
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";

    public Nationality Nationality { get; set; }
    public UserUsage UserUsage { get; set; }

}
