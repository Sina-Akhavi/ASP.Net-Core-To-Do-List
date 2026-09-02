using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models;

public class TaskItem
{
    
    public int Id { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    public bool IsCompleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }

    public PriorityLevel Priority { get; set; }

    public int TaskListId { get; set; }

    public bool IsDeleted { get; set; }

    public TaskList TaskList { get; set; } = null!;

}
