using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Api.Model
{
    public class ToDoSearchDto : SearchDto
    {
        public string Title { get; set; }
        public bool? Completed { get; set; }
    }
}
