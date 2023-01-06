using Microsoft.EntityFrameworkCore;
using TodoList_MySQL.Model;

namespace TodoList_MySQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<TodoGroup> TodoGroups { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Video> Videos { get; set; }
    }
}
