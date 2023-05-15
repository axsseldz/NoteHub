using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services.TodoListSevice
{
    public class TodoListService : ITodoListService
    {

        private static List<TodoList> todos = new List<TodoList>{
            new TodoList(),
            new TodoList {Id = 1, Content = "work"}
        };
        public async Task<List<TodoList>> AddTodo(TodoList newTodo)
        {
            todos.Add(newTodo);
            return todos;
        }

        public async Task<TodoList> GetTodoById(int id)
        {
            var todo = todos.FirstOrDefault(c => c.Id == id);

            if (todo is not null)
                return todo;

            throw new Exception("Todo not found");

        }

        public async Task<List<TodoList>> GetTodos()
        {
            return todos;
        }
    }
}