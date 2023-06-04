namespace Backend.Models;

public class TodoTask
{
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
        Enums.TaskPriority priority,
        string? description = null)
    {
        Id = id;
        Title = title;
        Description = description;
        DueDate = dueDate;
        IsCompleted = isCompleted;
        Priority = priority;
    }
}