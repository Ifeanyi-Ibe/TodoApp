using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.API.Models
{
    public class TodoItem
    {
        private static int _nextId = 1;

        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public bool IsCompleted { get; set; }

        public TodoItem()
        {
            Id = _nextId++; 
        }
    }
}