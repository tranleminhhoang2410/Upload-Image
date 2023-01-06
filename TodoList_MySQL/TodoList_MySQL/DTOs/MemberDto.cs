namespace TodoList_MySQL.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public ICollection<TodoDto> Todos { get; set; } = new List<TodoDto>();
        public ICollection<TodoGroupDto> Groups { get; set; } = new List<TodoGroupDto>();
        public string PhotoUrl { get; set; }
    }
}
