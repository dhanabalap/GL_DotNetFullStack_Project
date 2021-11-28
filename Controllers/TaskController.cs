using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GL_DotNetFullStack_Project.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace GL_DotNetFullStack_Project.Controllers
{
    
    [ApiController]
    public class TaskController : ControllerBase
    {
        private static int count = 4000;
        private static List<PTask> PTaskList = new List<PTask>
        {
            new PTask{ID=++count, ProjectID=1, Status=2, AssignedToUserID=102, Detail="PTest Task 1", CreatedOn=DateTime.Now},
            new PTask{ID=++count, ProjectID=2, Status=4, AssignedToUserID=101, Detail="PTest Task 2", CreatedOn=DateTime.Now},
            new PTask{ID=++count, ProjectID=3, Status=3, AssignedToUserID=103, Detail="PTest Task 3", CreatedOn=DateTime.Now},
            new PTask{ID=++count, ProjectID=2, Status=1, AssignedToUserID=103, Detail="PTest Task 4", CreatedOn=DateTime.Now},
        };

        [HttpGet]
        [Route("api/[controller]")]
        public List<PTask> GetAllPTasks()
        {
            return PTaskList;
        }

        [HttpGet]
        [Route("api/[controller]/{id}")] 
        public ActionResult<PTask> GetTaskById(int id)
        {
            try
            {
                var requestedPTask = PTaskList.FirstOrDefault(t => t.ID == id);
                if (requestedPTask == null)
                {
                    return NotFound("Project Task not Found");
                }
                return Ok(requestedPTask);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating project data ");
            }
        }

        [HttpPost]
        [Route("api/[controller]")]
        public ActionResult<PTask> CreateTask(PTask task)
        {
            try
            {
                if (task.ProjectID == 0 || task.Status == 0 || task.AssignedToUserID == 0 || task.Detail == null)
                {
                    return BadRequest();
                }

                var existingTask = PTaskList.FirstOrDefault(t => t.ID == task.ID);
                if (existingTask != null)
                {
                    return StatusCode(409, "TaskID already exists.");
                }
                task.ID = ++count;
                task.CreatedOn = DateTime.Now;
                PTaskList.Add(task);
                // return Ok(task);
                return Created(HttpContext.Request.Scheme + "://" +
                 HttpContext.Request.Host + HttpContext.Request.Path + "/" + task.ID, task);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating project data ");
            }
        }

        [HttpPut]
        [Route("api/[controller]")]
        public ActionResult<PTask> UpdateTask(PTask task)
        {
            try
            {
                var updatedTask = PTaskList.FirstOrDefault(t => t.ID == task.ID);
                if (updatedTask == null)
                {
                    return NotFound("Project TaskID:"+task.ID+" not found to update");
                }
                updatedTask.ProjectID = task.ProjectID;
                updatedTask.Status = task.Status;
                updatedTask.AssignedToUserID = task.AssignedToUserID;
                updatedTask.Detail = task.Detail;
                return Created(HttpContext.Request.Scheme + "://" +
                 HttpContext.Request.Host + HttpContext.Request.Path + "/" + task.ID, task);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Updating project data ");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTaskById(int id)
        {
            var deleteTask = PTaskList.FirstOrDefault(p => p.ID == id);
            if (deleteTask != null)
            {
                PTaskList.Remove(deleteTask);
                return Ok("Task Deleted successfully");
            }
            return NotFound("Task ID:" + id + " not Found to Delete"); ;
        }

    }
}
