using GL_DotNetFullStack_Project.Data;
using GL_DotNetFullStack_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestxUnit_Project
{
    public class ProjectMockServiceFake
    {
        private readonly AppDbContext _appDbContext;
        private static int count = 0;
        public ProjectMockServiceFake(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

            if (!_appDbContext.Projects.Any())
            {
                _appDbContext.Projects.Add(new Project() { ID = ++count, Name = "C# Project", Detail = "Detail for project 1", CreatedOn = DateTime.Now });
                _appDbContext.Projects.Add(new Project() { ID = ++count, Name = "ASP Core Project", Detail = "Detail for project 2", CreatedOn = DateTime.Now });
                _appDbContext.Projects.Add(new Project() { ID = ++count, Name = "ASP Core API Project", Detail = "Detail for project 3", CreatedOn = DateTime.Now });
                _appDbContext.Projects.Add(new Project() { ID = ++count, Name = "Project 4", Detail = "Detail for project 4", CreatedOn = DateTime.Now });
                _appDbContext.SaveChanges();
            }
        }
    }
}
