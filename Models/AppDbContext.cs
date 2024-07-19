using Microsoft.EntityFrameworkCore;

namespace webapitaskup.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team_Members> Team_Members { get; set; }
        public DbSet<SpExceptionsDetals> SpExceptionsDetals { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Statuses> Statuses { get; set; }
        public DbSet<complexity> complexity { get; set; }
        public DbSet<Priority> Priority { get; set; }
    }
}
