using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace TodoList_MySQL.Model
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public ICollection<Todo> Todos { get; set; } = new List<Todo>();
        public ICollection<TodoGroup> Groups { get; set; } = new List<TodoGroup>();
        public ICollection<Photo> Photos { get; set; }
    }
}
