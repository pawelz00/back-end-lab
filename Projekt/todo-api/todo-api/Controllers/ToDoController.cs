using todo_api.Dto;
using todo_api.Services;

namespace todo_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService todoservice;
        public ToDoController(IToDoService todoservice)
        { 
            this.todoservice = todoservice;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ToDoDto))]
        [ProducesResponseType(400)]
        public IActionResult GetTodo(int id)
        {
            if (!todoservice.TodoExists(id))
                return NotFound();

            var todo = new ToDoDto(todoservice.GetTodo(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(todo);
            
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ToDoDto>))]
        public IActionResult GetTodos()
        {
            var list = todoservice.GetTodos();
            var listDto = new List<ToDoDto>();
            foreach (var todo in list)
            {
                listDto.Add(new ToDoDto(todo));
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(listDto);
        }

        //[HttpPost("add")]
        //public ActionResult<ToDoDto> AddTodo(CreateToDoDto toDo)
        //{
        //    if (toDo == null)
        //        return BadRequest("Wrong!");
        //    service.CreateTodo(new ToDo()
        //    {
        //        Name = toDo.Name,
        //        Description = toDo.Description,
        //        Created = DateTime.UtcNow,
        //        Priority = priorityservice.GetPriority(toDo.PriorityId)
        //    }
        //    );
        //    return Ok(service.GetTodos());
        //}

        //[HttpPut]
        //public ActionResult<ToDoDto> UpdateTodo(UpdateToDoDto toDo)
        //{
        //    var todo = new ToDo() { Id = toDo.Id, Name = toDo.Name, Description = toDo.Description, Created = DateTime.UtcNow };
        //    todo = service.UpdateTodo(todo);
        //    if (todo is null)
        //        return NotFound("Todo not found!");
        //    return Ok(todo);
        //}

        //[HttpDelete("{id}")]
        //public ActionResult DeleteTodo(int id)
        //{
        //    service.DeleteTodo(id);
        //    if (service.GetTodoById(id) is null)
        //        return Ok("Succesfully deleted!");
        //    return BadRequest("Something's wrong");
        //}
    }
}
