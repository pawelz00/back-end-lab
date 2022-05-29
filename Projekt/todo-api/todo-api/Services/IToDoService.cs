
namespace todo_api.Services
{
    public interface IToDoService
    {
        List<ToDo> CreateTodo(ToDo todo);
        void DeleteTodo(int id);
        ToDo GetTodoById(int id);
        List<ToDo> GetTodos();
        ToDo UpdateTodo(ToDo todo);
    }
}