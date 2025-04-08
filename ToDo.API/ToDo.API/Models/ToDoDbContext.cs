using Microsoft.EntityFrameworkCore;

namespace ToDo.API.Models
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {
        }

        public DbSet<ToDoTask> Tasks { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
