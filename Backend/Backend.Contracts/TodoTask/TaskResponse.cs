namespace Backend.Contracts.TodoTask;

public record TaskResponse(
    Guid Id,
    string Name,
    string? Description,
    DateTime DueDate,
    bool IsCompleted,
    int Priority);