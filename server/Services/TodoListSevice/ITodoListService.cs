using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services.TodoListSevice
{
    public interface ITodoListService
    {
        Task<List<TodoList>> GetTodos();
        Task<TodoList> GetTodoById(int id);
        Task<List<TodoList>> AddTodo(TodoList newTodo);
    }
}