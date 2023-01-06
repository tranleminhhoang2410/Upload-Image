using System.ComponentModel.DataAnnotations;

namespace TodoList_MySQL.Model
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public ICollection<TodoGroup> Groups { get; set; }
        public Member Member { get; set; }

    }
}
