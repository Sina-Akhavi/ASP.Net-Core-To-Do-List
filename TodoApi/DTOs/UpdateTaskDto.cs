using System.ComponentModel.DataAnnotations;
using TodoApi.Models;

namespace TodoApi.DTOs;

public class UpdateTaskDto
{
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;


    public string? Description { get; set; }


    public DateTime? DueDate { get; set; }


    public PriorityLevel Priority { get; set; }
}