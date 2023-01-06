using System.ComponentModel;
using System.Reflection;

namespace TodoList_MySQL.DTOs
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
