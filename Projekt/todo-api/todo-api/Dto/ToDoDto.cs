using System.ComponentModel.DataAnnotations;

namespace todo_api.Dto
{
    public class ToDoDto
    {
        public ToDoDto(ToDo td)
        {
            Id = td.Id;
            Name = td.Name;
            Description = td.Description;
            Priority = td.Priority.Name;
            Created = td.Created;
            IsCompleted = td.IsCompleted;    
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public DateTime Created { get; set; }
        public bool IsCompleted { get; set; }
    }
}
