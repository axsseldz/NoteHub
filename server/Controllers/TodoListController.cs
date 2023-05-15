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
        public async Task<ActionResult<ServiceResponse<GetTodoDto>>> Get()
        {
            return Ok(await _todoService.GetTodos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTodoDto>>> GetSingle(int id)
        {
            return Ok(await _todoService.GetTodoById(id));
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetTodoDto>>>> AddTodo(AddTodoDto newTodo)
        {
            return Ok(await _todoService.AddTodo(newTodo));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetTodoDto>>>> UpdateTodo(UpdateTodoDto updatedTodo)
        {
            var response = await _todoService.UpdateTodo(updatedTodo);

            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTodoDto>>> DeleteTodo(int id)
        {
            var response = await _todoService.DeleteTodo(id);

            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }




    }
}