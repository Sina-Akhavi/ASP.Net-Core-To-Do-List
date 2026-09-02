using System.ComponentModel.DataAnnotations;

namespace TodoApi.DTOs;

public class CreateTaskListDto
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;
}
