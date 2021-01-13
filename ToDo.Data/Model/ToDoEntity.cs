using System;

namespace ToDo.Data.Model
{
    public class ToDoEntity
    {
        public DateTime CreationDate { get; set; }
        public int CreatedByUserId { get; set; }
        public bool Deleted { get; set; }
    }
}
