namespace Backend.Contracts.TodoTask;

public record UpdateTaskRequest(
    string Title,
    string? Description,
    DateTime DueDate,
    bool IsCompleted,
    string Priority);