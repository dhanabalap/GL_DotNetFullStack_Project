using System.Collections.Generic;
using GL_DotNetFullStack_Project.Models;

namespace GL_DotNetFullStack_Project.DataAccess.Repositories
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
