using Microsoft.EntityFrameworkCore;
using GL_ProjectManagement.BusinessEntities.Models;

namespace GL_ProjectManagement.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> optins) :base(optins)//same thing canbe passed to parent class constructor
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }

    }
}
