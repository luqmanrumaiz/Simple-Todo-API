namespace Backend.Contracts.TodoTask;

public record CreateTaskRequest(
    string Title,
    string? Description,
    DateTime DueDate,
    bool IsCompleted,
    string Priority);