using GL_ProjectManagement.BusinessEntities.Models;
using System.Collections.Generic;

namespace GL_ProjectManagement.BusinessEntities
{
    public interface ITaskRepository: IBaseRepository<Task>
    { 
        Task IsProjectTaskExists(int projectID, string taskDetail);
    }
}
