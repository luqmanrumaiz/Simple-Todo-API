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
    public ErrorOr<Updated> UpdateTask(Guid id, TodoTask updatedTask)
    {
        if (_todoTasks.Any(x => x.Key == id))
        {
            _todoTasks[id] = updatedTask;
            return Result.Updated;
        }

        return Errors.TodoTask.NotFound;
    }
}
