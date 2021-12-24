using System.Collections.Generic;
using GL_DotNetFullStack_Project.BusinessEntities.Models;

namespace GL_DotNetFullStack_Project.BusinessEntities
{
    public interface ITaskRepository
    {
        Task CreateTask(Task task);
        List<Task> GetAllTask();
        Task GetTaskById(int id);
        Task UpdateTask(Task task);
        bool DeleteTaskById(int id);
        Task IsProjectTaskExists(int projectID, string taskDetail);
    }
}
