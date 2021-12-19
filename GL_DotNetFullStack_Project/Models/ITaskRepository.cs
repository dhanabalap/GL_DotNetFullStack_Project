using System.Collections.Generic;

namespace GL_DotNetFullStack_Project.Models
{
    public interface ITaskRepository: IBaseRepository<Task>
    { 
        Task IsProjectTaskExists(int projectID, string taskDetail);
    }
}
