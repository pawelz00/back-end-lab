
namespace todo_api.Services
{
    public interface IToDoService
    {
        //List<ToDo> CreateTodo(ToDo todo);
        //void DeleteTodo(int id);
        ToDo GetTodo(int id);
        ICollection<ToDo> GetTodos();
        //ToDo UpdateTodo(ToDo todo);
        bool TodoExists(int todoId);
    }
}