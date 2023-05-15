using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TodoList, GetTodoDto>();
            CreateMap<AddTodoDto, TodoList>();

        }
    }
}