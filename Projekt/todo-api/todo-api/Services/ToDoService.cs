namespace todo_api.Services
{
    public class ToDoService : IToDoService
    {
        private readonly DataContext _context;

        public ToDoService(DataContext context)
        {
            _context = context;
        }

        public List<ToDo> GetTodos() => _context.Todos.ToList();

        public ToDo GetTodoById(int id)
        {
            var todo = _context.Todos.Find(id);
            if (todo == null)
                return null;
            return todo;
        }

        public List<ToDo> CreateTodo(ToDo todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
            return _context.Todos.ToList();
        }

        public void DeleteTodo(int id)
        {
            var todo = GetTodoById(id);
            _context.Todos.Remove(todo);
            _context.SaveChanges();
        }
    }
}
