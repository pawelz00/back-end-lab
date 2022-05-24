namespace todo_api.Models
{
    public class ToDo
    {
        public int Id { get; set; } = 0;
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime Created { get; set; }
    }
}
