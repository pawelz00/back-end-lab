namespace todo_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly DataContext _context;
        public ToDoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<ToDo> Get(int id)
        {
            var todo = _context.Todos.Find(id);
            if (todo == null)
                return BadRequest("Not found this todo.");
            return Ok(todo);
        }
        [HttpGet]
        public ActionResult<ToDo> Get()
        {
            return Ok(_context.Todos.ToList());
        }
        [HttpPost("add")]
        public ActionResult<ToDo> AddTodo(ToDo toDo)
        {
            if (toDo == null)
                return BadRequest("Wrong!");
            _context.Todos.Add(toDo);
            _context.SaveChanges();
            return Ok(toDo);
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
