using System.Collections.Generic;
using GL_ProjectManagement.BusinessEntities.Models;

namespace GL_ProjectManagement.BusinessEntities
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
