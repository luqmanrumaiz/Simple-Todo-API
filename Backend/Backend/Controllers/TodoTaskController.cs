using Backend.Contracts.TodoTask;
using Backend.Models;
using Backend.Services;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public class TodoTaskController : ApiController
{
    private readonly ITodoTaskService _taskService;

    public TodoTaskController(ITodoTaskService taskService)
    {
        _taskService = taskService;
    }


    // Helper method to map the Task model for the response
    private static TaskResponse MapTaskResponse(TodoTask task)
    {
        return new TaskResponse(
            task.Id,
            task.Title,
            task.Description,
            task.DueDate,
            task.IsCompleted,
            (int) task.Priority);
    }
}