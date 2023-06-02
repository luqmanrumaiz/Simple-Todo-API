using backend.Entities;

namespace backend.Services
{
    public interface ITaskService
    {
        IEnumerable<Entities.Task> GetAllTasks();
    }

    public class TaskService
    {
        private static readonly List<Entities.Task> Tasks = new List<Entities.Task>()
        {
            new Entities.Task {
                Id = 1,
                Title = "Test",
                Description = "Test",
                DueDate = DateTime.Now,
                IsCompleted = false,
                Priority = 0,
            }
        };

        public IEnumerable<Entities.Task> GetAllTasks() 
        {
            return Tasks;
        }
    }
}
