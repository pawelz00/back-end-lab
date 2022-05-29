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
        
        //[HttpPut]
        //public async Task<IActionResult> UpdateTodo(ToDo request)
        //{
        //    var td = todos.Find(t => t.Id == request.Id);
        //    if(td == null)
        //        return BadRequest("Todo not found");
        //    td.Name = request.Name;
        //    td.Description = request.Description;
        //    return Ok(todos);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var td = todos.Find(t => t.Id == id);
        //    if (td == null)
        //        return BadRequest("Todo not found");
        //    todos.Remove(td);
        //    return Ok(todos);
        //}
    }
}
