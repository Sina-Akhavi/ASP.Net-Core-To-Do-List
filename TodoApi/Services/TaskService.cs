using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.DTOs;
using TodoApi.Models;

namespace TodoApi.Services;

public class TaskService : ITaskService
{
    private readonly AppDbContext _context;


    public TaskService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TaskDto?> CreateAsync(int taskListId, CreateTaskDto dto)
    {
        var taskList = await _context.TaskLists
            .FirstOrDefaultAsync(
                x => x.Id == taskListId &&
                    !x.IsDeleted
            );


        if (taskList == null)
        {
            return null;
        }


        var task = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate,
            Priority = dto.Priority,

            TaskListId = taskListId,

            IsCompleted = false,
            IsDeleted = false,
            CreatedAt = DateTime.UtcNow
        };


        _context.Tasks.Add(task);

        await _context.SaveChangesAsync();


        return new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            Priority = task.Priority,
            IsCompleted = task.IsCompleted,
            CreatedAt = task.CreatedAt
        };
    }

    public async Task<TaskDto?> GetByIdAsync(int id)
    {
        return await _context.Tasks
            .Where(x =>
                x.Id == id &&
                !x.IsDeleted
            )
            .Select(x => new TaskDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                DueDate = x.DueDate,
                Priority = x.Priority,
                IsCompleted = x.IsCompleted,
                CreatedAt = x.CreatedAt
            })
            .FirstOrDefaultAsync();
    }


    public async Task<bool> UpdateAsync(int id, UpdateTaskDto dto)
    {
        var task = await _context.Tasks
            .FirstOrDefaultAsync(
                x => x.Id == id &&
                    !x.IsDeleted
            );


        if (task == null)
        {
            return false;
        }


        if (task.IsCompleted)
        {
            return false;
        }


        task.Title = dto.Title;
        task.Description = dto.Description;
        task.DueDate = dto.DueDate;
        task.Priority = dto.Priority;


        await _context.SaveChangesAsync();


        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var task = await _context.Tasks
            .FirstOrDefaultAsync(
                x => x.Id == id &&
                    !x.IsDeleted
            );


        if (task == null)
        {
            return false;
        }


        task.IsDeleted = true;


        await _context.SaveChangesAsync();


        return true;
    }

    public async Task<bool> CompleteAsync(int id)
    {
        var task = await _context.Tasks
            .FirstOrDefaultAsync(
                x => x.Id == id &&
                    !x.IsDeleted
            );


        if (task == null)
        {
            return false;
        }


        task.IsCompleted = true;


        await _context.SaveChangesAsync();


        return true;
    }


    public async Task<IEnumerable<TaskDto>> GetAllAsync(int taskListId)
    {
        return await _context.Tasks
            .Where(x =>
                x.TaskListId == taskListId &&
                !x.IsDeleted
            )
            .Select(x => new TaskDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                DueDate = x.DueDate,
                Priority = x.Priority,
                IsCompleted = x.IsCompleted,
                CreatedAt = x.CreatedAt
            })
            .ToListAsync();
    }

}
