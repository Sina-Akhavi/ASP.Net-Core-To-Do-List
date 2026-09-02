using System.ComponentModel.DataAnnotations;

namespace TodoApi.DTOs;

public class TaskListDto
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public string? ImageUrl { get; set; }

}