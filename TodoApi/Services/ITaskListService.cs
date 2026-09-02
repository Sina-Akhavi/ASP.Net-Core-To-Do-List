using TodoApi.DTOs;

namespace TodoApi.Services;

public interface ITaskListService
{
    Task<TaskListDto> CreateAsync(CreateTaskListDto dto);

    Task<IEnumerable<TaskListDto>> GetAllAsync();

    Task<TaskListDto?> GetByIdAsync(int id);

    Task<bool> UpdateAsync(int id, UpdateTaskListDto dto);

    Task<bool> DeleteAsync(int id);
}
