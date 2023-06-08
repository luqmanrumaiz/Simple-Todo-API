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
}