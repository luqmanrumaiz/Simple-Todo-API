using Backend.Contracts.TodoTask;
using Backend.Enums;
using Backend.ServiceErrors;
using ErrorOr;

namespace Backend.Models;

public class TodoTask
{
    public const int MinTitleLength = 3;
    public const int MaxTitleLength = 50;

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public Enums.TaskPriority Priority { get; set; }

    private TodoTask(
        Guid id,
        string title,
        DateTime dueDate,
        bool isCompleted,
        TaskPriority priority,
        string? description = null)
    {
        Id = id;
        Title = title;
        Description = description;
        DueDate = dueDate;
        IsCompleted = isCompleted;
        Priority = priority;
    }

    public static ErrorOr<TodoTask> Create(
        string title,
        DateTime dueDate,
        bool isCompleted,
        TaskPriority priority,
        string? description = null,
        Guid? id = null)
    {
        List<Error> errors = new();

        if (title.Length is < MinTitleLength or > MaxTitleLength)
        {
            errors.Add(Errors.TodoTask.InvalidName);
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        return new TodoTask(
            id ?? Guid.NewGuid(),
            title,
            dueDate,
            isCompleted,
            priority,
            description ?? "");
    }

    public static ErrorOr<TodoTask> From(CreateTaskRequest request)
    {
        return Create(
            request.Title,
            request.DueDate,
            request.IsCompleted,
            Enum.Parse<TaskPriority>(request.Priority),
            request.Description);
    }
}