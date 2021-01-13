using System;

namespace ToDo.Api.Model
{
    public class TodoNotFoundException : Exception
    {
        public TodoNotFoundException(string message) : base(message)
        {
        }
    }
}
