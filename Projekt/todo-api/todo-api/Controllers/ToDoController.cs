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
        public ActionResult<ToDo> Get(int id)
        {
            var todo = service.GetTodoById(id);
            if (todo == null)
                return BadRequest("Not found this todo.");
            return Ok(todo);
        }
        [HttpGet]
        public ActionResult<List<ToDo>> Get()
        {
            var list = service.GetTodos();
            if (list is null)
                return BadRequest("There are no todos.");
            return Ok(list);
        }
        [HttpPost("add")]
        public ActionResult<ToDo> AddTodo(ToDo toDo)
        {
            if (toDo == null)
                return BadRequest("Wrong!");
            service.CreateTodo(toDo);
            return Ok(service.GetTodos());
        }

        [HttpPut]
        public ActionResult<ToDo> UpdateTodo(ToDo toDo)
        {
            var todo = service.UpdateTodo(toDo);
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
