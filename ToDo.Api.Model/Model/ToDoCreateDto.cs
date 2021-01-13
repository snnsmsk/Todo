using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Api.Model
{
    public class ToDoCreateDto
    {
        [Required]
        [MaxLength(1000)]
        public string Title { get; set; }
    }
}
