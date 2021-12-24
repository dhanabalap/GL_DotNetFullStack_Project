using System.Collections.Generic;
using GL_DotNetFullStack_Project.Models;
namespace GL_DotNetFullStack_Project.DataAccess.Repositories
{
    public interface IProjectRepository
    {
        Project CreateProject(Project project);
        List<Project> GetAllProject();
        Project GetProjectById(int id);
        Project GetProjectByName(string name);
        Project UpdateProject(Project project); 
        bool DeleteProjectById(int id);
    }
}
