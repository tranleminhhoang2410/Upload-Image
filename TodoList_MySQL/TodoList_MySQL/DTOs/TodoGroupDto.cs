namespace TodoList_MySQL.DTOs
{
    public class TodoGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TodoDto> Todos { get; set; }
    }
}
