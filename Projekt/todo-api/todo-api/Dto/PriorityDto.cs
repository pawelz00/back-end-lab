namespace todo_api.Dto
{
    public class PriorityDto
    {
        public PriorityDto(Priority priority)
        {
            PriorityId = priority.PriorityId;
            Name = priority.Name;
        }

        public int PriorityId { get; set; }
        public string? Name { get; set; }
    }
}
