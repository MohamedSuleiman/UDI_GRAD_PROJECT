using System;
using System.ComponentModel.DataAnnotations;
using LlmService.Domain.Enum;

namespace Backend.Domain.DTO;

public class UpdateUserDto
{
    [MinLength(1)]
    public string? FirstName { get; set; }
    [MinLength(1)]
    public string? LastName { get; set; }


}
