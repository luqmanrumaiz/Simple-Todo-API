using Backend.Models;
using Backend.ServiceErrors;
using ErrorOr;

namespace Backend.Services.Task;

public class TodoTaskService : ITodoTaskService
{
    private static readonly Dictionary<Guid, TodoTask> _todoTasks = new();

    public ErrorOr<Created> AddTask(TodoTask todoTask)
    {        
        _todoTasks.Add(todoTask.Id, todoTask);

        return Result.Created;
    }

    public ErrorOr<TodoTask> GetTask(Guid id)
    {
        if (_todoTasks.TryGetValue(id, out var todoTask))
        {
            return todoTask;
        }

        return Errors.TodoTask.NotFound;
    }
}
