using GL_DotNetFullStack_Project.BusinessEntities.Models;
using GL_DotNetFullStack_Project.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GL_DotNetFullStack_Project.DataAccess.Repositories
{
    public class ProjectRepoSqlEfImpl : IProjectRepository
    {
        private readonly AppDbContext _appDbContext;
        private static int count = 0;
        public ProjectRepoSqlEfImpl(AppDbContext appDbContext)
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
        public Project CreateProject(Project project)
        {
            if (project == null)
            {
                return null;
            }
            else               
            {
                project.ID = ++count;
                project.CreatedOn = DateTime.Now;

                _appDbContext.Projects.Add(project);
                _appDbContext.SaveChanges();
                return project;
            }        
        }

        public bool DeleteProjectById(int id)
        {
            Project deletProject = GetProjectById(id);
            if (deletProject != null)
            {
                _appDbContext.Projects.Remove(deletProject);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Project> GetAllProject()
        {
            return _appDbContext.Projects.ToList();
        }

        public Project GetProjectById(int id)
        {
            return _appDbContext.Projects.FirstOrDefault(prj => prj.ID == id);
        }

        public Project GetProjectByName(string name)
        {
            return _appDbContext.Projects.FirstOrDefault(prj => prj.Name == name);
        }

        public Project UpdateProject(Project project)
        {
            Project updProject = _appDbContext.Projects.FirstOrDefault(p => p.ID == project.ID);
            if (updProject != null)
            {
                updProject.Name = project.Name;
                updProject.Detail = project.Detail;

                _appDbContext.Projects.Update(updProject);
                _appDbContext.SaveChanges();
                return updProject;
            }
            return null;
        }
    }
}
