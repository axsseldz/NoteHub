using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Todo
{
    public class AddTodoDto
    {
        public string Title { get; set; } = "food";
        public string Content { get; set; } = "eat";

    }
}