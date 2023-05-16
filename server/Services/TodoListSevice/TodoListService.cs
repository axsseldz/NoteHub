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
        private readonly DataContext _context;

        public TodoListService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetTodoDto>>> AddTodo(AddTodoDto newTodo)
        {
            var serviceResponse = new ServiceResponse<List<GetTodoDto>>();

            try
            {
                var todo = _mapper.Map<TodoList>(newTodo);
                todo.CreatedDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Pacific Standard Time");
                await _context.todos.AddAsync(todo);
                await _context.SaveChangesAsync();



                serviceResponse.Data = await _context.todos.Select(c => _mapper.Map<GetTodoDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTodoDto>>> DeleteTodo(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetTodoDto>>();

            try
            {
                var todo = await _context.todos.FirstOrDefaultAsync(c => c.Id == id);

                if (todo is null)
                    throw new Exception($"Todo with ID '{id}' not found.");

                _context.todos.Remove(todo);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.todos
                    .Select(c => _mapper.Map<GetTodoDto>(c))
                    .ToListAsync();
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
            var dbTodo = await _context.todos.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetTodoDto>(dbTodo);
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetTodoDto>>> GetTodos()
        {
            var serviceResponse = new ServiceResponse<List<GetTodoDto>>();
            var dbTodos = await _context.todos.ToListAsync();
            serviceResponse.Data = dbTodos.Select(c => _mapper.Map<GetTodoDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTodoDto>> UpdateTodo(UpdateTodoDto updatedTodo)
        {
            var serviceResponse = new ServiceResponse<GetTodoDto>();

            try
            {
                var todo = await _context.todos.FirstOrDefaultAsync(c => c.Id == updatedTodo.Id);

                if (todo is null)
                    throw new Exception($"Todo with ID '{updatedTodo.Id}' not found.");

                todo.Title = updatedTodo.Title;
                todo.Content = updatedTodo.Content;
                todo.CreatedDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Pacific Standard Time");
                await _context.SaveChangesAsync();

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