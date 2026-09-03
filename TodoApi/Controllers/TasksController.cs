using Microsoft.AspNetCore.Mvc;
using TodoApi.DTOs;
using TodoApi.Services;

namespace TodoApi.Controllers;


[ApiController]
[Route("api")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _service;


    public TasksController(ITaskService service)
    {
        _service = service;
    }


    // POST: /api/tasklists/{taskListId}/tasks
    [HttpPost("tasklists/{taskListId}/tasks")]
    public async Task<IActionResult> Create(
        int taskListId,
        CreateTaskDto dto)
    {
        var result = await _service.CreateAsync(
            taskListId,
            dto
        );


        if (result == null)
        {
            return NotFound();
        }


        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Id },
            result
        );
    }


    // GET: /api/tasklists/{taskListId}/tasks
    [HttpGet("tasklists/{taskListId}/tasks")]
    public async Task<IActionResult> GetAll(int taskListId)
    {
        var result = await _service.GetAllAsync(
            taskListId
        );

        return Ok(result);
    }


    // GET: /api/tasks/{id}
    [HttpGet("tasks/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);


        if (result == null)
        {
            return NotFound();
        }


        return Ok(result);
    }


    // PUT: /api/tasks/{id}
    [HttpPut("tasks/{id}")]
    public async Task<IActionResult> Update(int id, UpdateTaskDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }


    // DELETE: /api/tasks/{id}
    [HttpDelete("tasks/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }


    // PATCH: /api/tasks/{id}/complete
    [HttpPatch("tasks/{id}/complete")]
    public async Task<IActionResult> Complete(
        int id)
    {
        var result = await _service.CompleteAsync(id);


        if (!result)
        {
            return NotFound();
        }


        return NoContent();
    }
}