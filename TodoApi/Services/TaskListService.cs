using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.DTOs;
using TodoApi.Models;

namespace TodoApi.Services;

public class TaskListService : ITaskListService
{
    private readonly AppDbContext _context;


    public TaskListService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TaskListDto> CreateAsync(CreateTaskListDto dto)
    {
        var taskList = new TaskList
        {
            Name = dto.Name,
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false
        };
        
        _context.TaskLists.Add(taskList);

        await _context.SaveChangesAsync();

        return new TaskListDto
        {
            Id = taskList.Id,

            Name = taskList.Name,

            ImageUrl = taskList.ImageUrl,

            CreatedAt = taskList.CreatedAt
        };
    }


    public async Task<IEnumerable<TaskListDto>> GetAllAsync()
    {
        return await _context.TaskLists
            .Where(x => !x.IsDeleted)
            .Select(x => new TaskListDto
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                CreatedAt = x.CreatedAt
            })
            .ToListAsync();
    }
}
