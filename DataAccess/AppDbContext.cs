using Microsoft.EntityFrameworkCore;
using GL_DotNetFullStack_Project.Models;

namespace GL_DotNetFullStack_Project.DataAccess
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
