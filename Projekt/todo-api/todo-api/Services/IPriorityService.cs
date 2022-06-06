namespace todo_api.Services
{
    public interface IPriorityService
    {
        public Priority GetPriority(int id);
        //public Priority GetPriorityByTodo(int todoId);
        public bool PriorityExists(int id);
    }
}
