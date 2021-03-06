﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Api.Model
{
    public class ToDoUpdateDto
    {
        [Required]
        [MaxLength(1000)]
        public string Title { get; set; }
        [Required]
        public bool Completed { get; set; }
    }
}
