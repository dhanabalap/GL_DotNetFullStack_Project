using System.Collections.Generic;
using GL_ProjectManagement.BusinessEntities.Models;
namespace GL_ProjectManagement.BusinessEntities
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
