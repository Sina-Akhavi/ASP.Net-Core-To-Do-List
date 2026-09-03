using TodoApi.DTOs;

namespace TodoApi.Services;

public interface ITaskService
{
    Task<TaskDto?> CreateAsync(int taskListId, CreateTaskDto dto);


    Task<IEnumerable<TaskDto>> GetAllAsync(int taskListId);


    Task<TaskDto?> GetByIdAsync(int id);


    Task<bool> UpdateAsync(int id, UpdateTaskDto dto);


    Task<bool> DeleteAsync(int id);


    Task<bool> CompleteAsync(int id);
}