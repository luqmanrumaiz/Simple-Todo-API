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

    // HTTP POST action to create a task
    [HttpPost]
    public IActionResult CreateTask(CreateTaskRequest request)
    {
        // Converting the request into a TodoTask using the From method
        ErrorOr<TodoTask> requestToTaskResult = TodoTask.From(request);

        // Checking if there are any errors in the conversion
        if (requestToTaskResult.IsError)
        {
            // Returning a problem response with the errors
            return Problem(requestToTaskResult.Errors);
        }

        // Extracting the TodoTask object from the converted request
        var task = requestToTaskResult.Value;

        ErrorOr<Created> addTaskResult = _taskService.AddTask(task);

        // The Match method make returns the response in the first lambda, else a Problem obj. is returned
        return addTaskResult.Match(

            // Using the CreatedAtActionResult Obj. as it returns the URI to the created resource in the response
            created => CreatedAtGetTask(task),
            errors => Problem(errors));
    }

    // HTTP GET action to get a task by ID
    [HttpGet("{id:guid}")]
    public IActionResult GetTask(Guid id)
    {
        // Getting the task by ID using the task service
        ErrorOr<TodoTask> getTaskResult = _taskService.GetTask(id);

        // Handling the result of getting the task
        return getTaskResult.Match(
            task => Ok(MapTaskResponse(task)),
            errors => Problem(errors));
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

    // Helper method to create a CreatedAtActionResult for GetTask action
    private CreatedAtActionResult CreatedAtGetTask(TodoTask task)
    {
        return CreatedAtAction(
            actionName: nameof(GetTask),
            routeValues: new { id = task.Id },
            value: MapTaskResponse(task));
    }
}