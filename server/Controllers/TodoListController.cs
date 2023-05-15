global using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoListController : ControllerBase
    {

        private readonly ITodoListService _todoService;

        public TodoListController(ITodoListService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<TodoList>> Get()
        {
            return Ok(await _todoService.GetTodos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoList>> GetSingle(int id)
        {
            return Ok(await _todoService.GetTodoById(id));
        }


        [HttpPost]
        public async Task<ActionResult<List<TodoList>>> AddTodo(TodoList newTodo)
        {
            return Ok(await _todoService.AddTodo(newTodo));
        }



    }
}