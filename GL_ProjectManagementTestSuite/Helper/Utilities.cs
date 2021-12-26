using GL_ProjectManagement.BusinessEntities.Models;
using GL_ProjectManagement.DataAccess.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using Task = GL_ProjectManagement.BusinessEntities.Models.Task;

namespace GL_ProjectManagementTestSuite.Helper
{
    public static class Utilities
    {
        #region snippet1
        public static void InitializeDbForTests(AppDbContext db)
        {
            db.Projects.AddRange(GetSeedingProjects());
            db.SaveChanges();
            db.Tasks.AddRange(GetSeedingTasks());
            db.SaveChanges();
            db.Users.AddRange(GetSeedingUsers());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(AppDbContext db)
        {
            // db.Messages.RemoveRange(db.Messages);
            db.Projects.RemoveRange(db.Projects);
            db.Tasks.RemoveRange(db.Tasks);
            db.Users.RemoveRange(db.Users);
            InitializeDbForTests(db);
        }

        public static List<Project> GetSeedingProjects()
        {
            return new List<Project>()
            {
                new Project() { ID = 11, Name = "AI", Detail = "Artificial Inteligence 1", CreatedOn = DateTime.Now },
                new Project() { ID = 12, Name = "Fullstack", Detail = "Detail for project 2", CreatedOn = DateTime.Now }
            };
        }

        public static List<Task> GetSeedingTasks()
        {
            return new List<Task>()
            {
                    new Task() { ID = 111, ProjectID = 11, Status = 2, AssignedToUserID = 1011, Detail = "PTest Task 1", CreatedOn = DateTime.Now },
                    new Task() { ID = 112, ProjectID = 12, Status = 2, AssignedToUserID = 1012, Detail = "PTest Task 1", CreatedOn = DateTime.Now }
            };
        }


        public static List<User> GetSeedingUsers()
        {
            return new List<User>()
                    {
                    new User() { ID = 1011, FirstName = "Sathis", LastName = "T", Email = "sathis@gmail.com", Password = "T123" },
                    new User() { ID = 1012, FirstName = "Sangeetha", LastName = "D", Email = "sangeetha@gmail.com", Password = "D123" }
                };
        }

        #endregion
    }
}
