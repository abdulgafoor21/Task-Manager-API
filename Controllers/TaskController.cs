using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerAPI.Controllers;

public class TaskController:BaseController
{
    public readonly TaskManagerContext _context;
    
    public TaskController(TaskManagerContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    //Create a new Task
    [HttpPost]
    [Route("AddTask")]
    public async Task<IActionResult> AddTask([FromBody] TaskModel tm)
    {
        if (tm is null)
        {
            BadRequest();
        }

        var taskManager = new TaskManager
        {
            Id = Guid.NewGuid().ToString(),
            Title = tm.Title,
            Description = tm.Description,
            Priority = tm.Priority,
            Status = tm.Status,
            CreatedAt = DateTime.Now,
            DueDate = DateTime.Now.AddDays(7),
            UpdatedAt = null
        };

        await _context.TaskManagers.AddAsync(taskManager);
        await _context.SaveChangesAsync();

        return Ok("Task added successfully");
    }

    [HttpGet]
    [Route("GetAllTasks")]
    public async Task<IActionResult> GetTasks()
    {
        var tasks = await _context.TaskManagers.ToListAsync();
        return Ok(tasks);
    }

    [HttpGet]
    [Route("{Id}")]
    public async Task<IActionResult> GetTaskById(Guid Id)
    {
        var task = await _context.TaskManagers.FindAsync(Id.ToString());
        return Ok(task);
    }

    [HttpPut]
    [Route("{Id}")]
    public async Task<IActionResult> UpdateTaskById(Guid Id, [FromBody] TaskModel tm)
    {
        var task = await _context.TaskManagers.FindAsync(Id.ToString());

        task.Description = tm.Description;
        task.Priority = tm.Priority;
        task.Status = tm.Status;
        task.Title = tm.Title;
        task.UpdatedAt=DateTime.Now;

        await _context.SaveChangesAsync();

        return Ok(task);
    }

    [HttpDelete]
    [Route("{Id}")]
    public async Task<IActionResult> RemoveTask(Guid Id)
    {
        var task = await _context.TaskManagers.FindAsync(Id.ToString());
        _context.TaskManagers.Remove(task);
        await _context.SaveChangesAsync();

        return Ok();
    }
}