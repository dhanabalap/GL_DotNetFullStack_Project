using System.Collections.Generic;

namespace GL_DotNetFullStack_Project.Models
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
