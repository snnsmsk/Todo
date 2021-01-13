using System;

namespace ToDo.Api.Model
{
    public class ToDoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
