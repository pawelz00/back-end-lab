using todo_api.Dto;
using todo_api.Services;

namespace todo_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService service;
        public ToDoController(IToDoService service)
        { 
             this.service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<ToDoDto> Get(int id)
        {
            var todo = service.GetTodoById(id);
            if (todo == null)
                return BadRequest("Not found this todo.");
            return Ok(todo.AsDto());
        }
        [HttpGet]
        public ActionResult<List<ToDoDto>> Get()
        {
            var list = service.GetTodos();
            if (list is null)
                return BadRequest("There are no todos.");
            return Ok(list);
        }
        [HttpPost("add")]
        public ActionResult<ToDoDto> AddTodo(CreateToDoDto toDo)
        {
            if (toDo == null)
                return BadRequest("Wrong!");
            service.CreateTodo(new ToDo()
            {
                Name = toDo.Name,
                Description = toDo.Description,
                Created = DateTime.UtcNow
            }
            );
            return Ok(service.GetTodos());
        }

        [HttpPut]
        public ActionResult<ToDoDto> UpdateTodo(UpdateToDoDto toDo)
        {
            var todo = new ToDo() { Id = toDo.Id, Name = toDo.Name, Description = toDo.Description, Created = DateTime.UtcNow };
            todo = service.UpdateTodo(todo);
            if (todo is null)
                return NotFound("Todo not found!");
            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTodo(int id)
        {
            service.DeleteTodo(id);
            if (service.GetTodoById(id) is null)
                return Ok("Succesfully deleted!");
            return BadRequest("Something's wrong");
        }
    }
}
