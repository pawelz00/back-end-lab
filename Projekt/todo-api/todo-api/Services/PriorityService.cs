namespace todo_api.Services
{
    public class PriorityService : IPriorityService
    {
        private readonly DataContext _context;

        public PriorityService(DataContext context)
        {
            _context = context;
        }

        public Priority GetPriority(int id)
        {
            return _context.Priorities.Where(p => p.PriorityId == id).FirstOrDefault();
        }

        //public Priority GetPriorityByTodo(int todoId)
        //{
        //    return _context.Todos.Where(td => td.Id == todoId).Select(p => p.Priority).FirstOrDefault();
        //}

        public bool PriorityExists(int id)
        {
            return _context.Priorities.Any(p => p.PriorityId == id);
        }
    }
}
