using System;

namespace ToDo.Api.Model
{
    public class TodoException : Exception
    {
        public TodoException(string message) : base(message)
        {
        }
    }
}
