using GL_DotNetFullStack_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GL_DotNetFullStack_Project.Models
{
    public class TaskRepoSqlEFImpl : ITaskRepository
    { 
        private readonly AppDbContext _appDbContext;
        private static int count = 4000;
        public TaskRepoSqlEFImpl(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

            if (!_appDbContext.Tasks.Any())
            {
                _appDbContext.Tasks.Add(new Task() { ID = ++count, ProjectID = 1, Status = 2, AssignedToUserID = 102, Detail = "PTest Task 1", CreatedOn = DateTime.Now });
                _appDbContext.Tasks.Add(new Task() { ID = ++count, ProjectID = 2, Status = 4, AssignedToUserID = 101, Detail = "PTest Task 2", CreatedOn = DateTime.Now });
                _appDbContext.Tasks.Add(new Task() { ID = ++count, ProjectID = 3, Status = 3, AssignedToUserID = 103, Detail = "PTest Task 3", CreatedOn = DateTime.Now });
                _appDbContext.Tasks.Add(new Task() { ID = ++count, ProjectID = 2, Status = 1, AssignedToUserID = 103, Detail = "PTest Task 4", CreatedOn = DateTime.Now });
                _appDbContext.SaveChanges();
            }

        }
        public Task CreateTask(Task task)
        {
            if (task == null)
            {
                return null;
            }
            else
            {
                task.ID = ++count;
                task.CreatedOn = DateTime.Now;

                _appDbContext.Tasks.Add(task);
                _appDbContext.SaveChanges();
                return task;
            }
        }

        public bool DeleteTaskById(int id)
        {
            Task delettask = GetTaskById(id);
            if (delettask != null)
            {
                _appDbContext.Tasks.Remove(delettask);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Task> GetAllTask()
        {
            return _appDbContext.Tasks.ToList();
        }

        public Task GetTaskById(int id)
        {
            return _appDbContext.Tasks.FirstOrDefault(task => task.ID == id);
        } 
        public Task UpdateTask(Task task)
        {
            Task updTask = GetTaskById(task.ID);
            if (updTask == null)
            {
                return null;// NotFound();
            }
            updTask.ProjectID = task.ProjectID;
            updTask.Status = task.Status;
            updTask.AssignedToUserID = task.AssignedToUserID;
            updTask.Detail = task.Detail;


            _appDbContext.Tasks.Update(updTask);
            _appDbContext.SaveChanges();

            return updTask; 
        }

        public Task IsProjectTaskExists(int projectID, string taskDetail)
        {
            return _appDbContext.Tasks.FirstOrDefault(task => task.ProjectID == projectID && task.Detail == taskDetail);
        }
    }
}
