using backend.Enums;

namespace backend.Entities
{
    public class Task
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Status { get; set; }
        public TaskPriority Priority { get; set; }
    }
}