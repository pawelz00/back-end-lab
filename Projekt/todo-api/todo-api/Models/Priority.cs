namespace todo_api.Models
{
    public class Priority
    {
        public int PriorityId { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<ToDo> ToDos { get; set; }
    }
}
