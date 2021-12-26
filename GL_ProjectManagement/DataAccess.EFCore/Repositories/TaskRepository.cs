using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using GL_ProjectManagement.BusinessEntities.Models;
using GL_ProjectManagement.DataAccess.EFCore.Repositories;

namespace GL_ProjectManagement.DataAccess.EFCore.Repositories
{
    public class TaskRepository  : BaseRepository<Task, AppDbContext>
    { 
        private readonly AppDbContext _appDbContext;
        private static int count = 4000;
        public TaskRepository(AppDbContext appDbContext) : base(appDbContext)
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
        public Task IsProjectTaskExists(int projectID, string taskDetail)
        {
            return _appDbContext.Tasks.FirstOrDefault(task => task.ProjectID == projectID && task.Detail == taskDetail);
        }
        /*
        public new async Task<Task> Update(Task entity)
        {
            var updEntity = await _appDbContext.Set<Task>().FindAsync(entity.ID); 
            //_appDbContext.Tasks.FirstOrDefault(p => p.ID == entity.ID);
            if (updEntity != null)
            {
                updEntity.ProjectID = entity.ProjectID;
                updEntity.Status = entity.Status;
                updEntity.AssignedToUserID = entity.AssignedToUserID;
                updEntity.Detail = entity.Detail;

                _appDbContext.Entry(updEntity).State = EntityState.Modified;
                await _appDbContext.SaveChangesAsync();
                return updEntity;
            }
            return null;
        }
          */
    }
}
