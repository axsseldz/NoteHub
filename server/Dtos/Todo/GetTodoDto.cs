using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Todo
{
    public class GetTodoDto
    {
        public int Id { get; set; } = 0;
        public string Content { get; set; } = "eat";

    }
}