using System.ComponentModel.DataAnnotations;

namespace TodoList_MySQL.Model
{
    public class TodoGroup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Todo> Todos { get; set; }
        public Member Member { get; set; }
    }
}
