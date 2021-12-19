using GL_DotNetFullStack_Project.Data;
using GL_DotNetFullStack_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestxUnit_Project.Helper
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
                    new Project() { ID = 1, Name = "AI", Detail = "Artificial Inteligence 1", CreatedOn = DateTime.Now },
                    new Project() { ID = 2, Name = "Fullstack", Detail = "Detail for project 2", CreatedOn = DateTime.Now }
            };
            }
            public static List<GL_DotNetFullStack_Project.Models.Task> GetSeedingTasks()
            {
                return new List<GL_DotNetFullStack_Project.Models.Task>()
                {
                       new GL_DotNetFullStack_Project.Models.Task() { ID = 100, ProjectID = 1, Status = 2, AssignedToUserID = 102, Detail = "PTest Task 1", CreatedOn = DateTime.Now },
                       new GL_DotNetFullStack_Project.Models.Task() { ID = 101, ProjectID = 1, Status = 2, AssignedToUserID = 102, Detail = "PTest Task 1", CreatedOn = DateTime.Now }
                };
            }

            public static List<User> GetSeedingUsers()
            {
                return new List<User>()
                 {
                     new User() { ID = 1001, FirstName = "Sathis", LastName = "T", Email = "sathis@gmail.com", Password = "T123" },
                    new User() { ID = 1002, FirstName = "Sangeetha", LastName = "D", Email = "sangeetha@gmail.com", Password = "D123" }
                };
            }
        #endregion
    }
 }

