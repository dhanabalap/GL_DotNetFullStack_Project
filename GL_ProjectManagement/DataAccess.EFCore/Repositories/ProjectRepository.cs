using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GL_ProjectManagement.BusinessEntities;
using GL_ProjectManagement.BusinessEntities.Models;

namespace GL_ProjectManagement.DataAccess.EFCore.Repositories
{
    public class ProjectRepository : BaseRepository<Project,AppDbContext>
    {
        private readonly AppDbContext _appDbContext;
        private static int count = 0;
       
        public ProjectRepository(AppDbContext appDbContext) : base(appDbContext)
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
        
        /*
        public new async Task<Project> Update(Project entity)
        {
            var updProject = _appDbContext.Projects.FirstOrDefault(p => p.ID == entity.ID);
            if (updProject != null)
            {
                updProject.Name = entity.Name;
                updProject.Detail = entity.Detail;

                _appDbContext.Entry(entity).State = EntityState.Modified;
                await _appDbContext.SaveChangesAsync();
                return updProject;
            }
            return null;
        }
         */
    }
}
