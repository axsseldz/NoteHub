using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services.TodoListSevice
{
    public interface ITodoListService
    {
        Task<ServiceResponse<List<GetTodoDto>>> GetTodos();
        Task<ServiceResponse<GetTodoDto>> GetTodoById(int id);
        Task<ServiceResponse<List<GetTodoDto>>> AddTodo(AddTodoDto newTodo);
        Task<ServiceResponse<GetTodoDto>> UpdateTodo(UpdateTodoDto updatedTodo);
        Task<ServiceResponse<List<GetTodoDto>>> DeleteTodo(int id);
    }
}