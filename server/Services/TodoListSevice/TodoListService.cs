global using AutoMapper;
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
        private readonly IMapper _mapper;

        public TodoListService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetTodoDto>>> AddTodo(AddTodoDto newTodo)
        {
            var serviceResponse = new ServiceResponse<List<GetTodoDto>>();
            var todo = _mapper.Map<TodoList>(newTodo);
            todo.Id = todos.Max(c => c.Id) + 1;
            todos.Add(todo);
            serviceResponse.Data = todos.Select(c => _mapper.Map<GetTodoDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTodoDto>>> DeleteTodo(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetTodoDto>>();

            try
            {
                var todo = todos.First(c => c.Id == id);

                if (todo is null)
                    throw new Exception($"Note with ID '{id}' not found.");

                todos.Remove(todo);

                serviceResponse.Data = todos.Select(c => _mapper.Map<GetTodoDto>(c)).ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTodoDto>> GetTodoById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTodoDto>();
            var todo = todos.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetTodoDto>(todo);
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetTodoDto>>> GetTodos()
        {
            var serviceResponse = new ServiceResponse<List<GetTodoDto>>();
            serviceResponse.Data = todos.Select(c => _mapper.Map<GetTodoDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTodoDto>> UpdateTodo(UpdateTodoDto updatedTodo)
        {
            var serviceResponse = new ServiceResponse<GetTodoDto>();

            try
            {
                var todo = todos.FirstOrDefault(c => c.Id == updatedTodo.Id);

                if (todo is null)
                    throw new Exception($"Note with ID '{updatedTodo.Id}' not found.");

                todo.Content = updatedTodo.Content;
                serviceResponse.Data = _mapper.Map<GetTodoDto>(todo);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }

            return serviceResponse;
        }
    }
}