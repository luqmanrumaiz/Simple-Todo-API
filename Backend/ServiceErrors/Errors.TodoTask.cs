using ErrorOr;

namespace Backend.ServiceErrors;

public static class Errors
{
    public static class TodoTask
    {
        public static Error InvalidName => Error.Validation(
            code: "Task.InvalidName",
            description: $"Task name must be at least {Models.TodoTask.MinTitleLength}" +
                $" characters long and at most {Models.TodoTask.MaxTitleLength} characters long.");

        public static Error NotFound => Error.NotFound(
            code: "Task.NotFound",
            description: "Breakfast not found");
    }
}