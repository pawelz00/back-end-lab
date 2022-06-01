using todo_api.Dto;

namespace todo_api
{
    public static class Extensions
    {
        public static ToDoDto AsDto(this ToDo toDo)
        {
            var dto = new ToDoDto
            {
                Id = toDo.Id,
                Name = toDo.Name,
                Description = toDo.Description,
                Created = DateTime.Now
            };

            return dto;
        }
    }
}
