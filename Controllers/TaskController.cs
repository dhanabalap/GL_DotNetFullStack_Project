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
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        { 
            _taskRepository = taskRepository;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult Get()
        {
            try
            {
                return Ok(_taskRepository.GetAllTask());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data ");
            }
        }

        [HttpGet]
        [Route("api/[controller]/{id}")] 
        public ActionResult<Task> GetTaskById(int id)
        {
            try
            {
                var data = _taskRepository.GetTaskById(id);
                if (data == null)
                {
                    return NotFound("Task Record not Found");
                }
                return Ok(data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data ");
            }             
        }

        [HttpPost]
        [Route("api/[controller]")]
        public ActionResult<Task> CreateTask(Task task)
        {
            try
            {
                if (task.ProjectID == 0 || task.Status == 0 || task.AssignedToUserID == 0 || task.Detail == null)
                {
                    return BadRequest();
                }
                Task taskexist = _taskRepository.IsProjectTaskExists(task.ProjectID,task.Detail);
                //is Task exist By Project Id and Task detail 
                if (taskexist != null)
                {
                    return StatusCode(409, "Trying create Project Id :"+ task.ProjectID+" and Task:"+task.Detail+" is already exists");
                }

                Task createdTask = _taskRepository.CreateTask(task);
                
                return Created(HttpContext.Request.Scheme + "://" +
                 HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdTask.ID, createdTask);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Creating Task for the porject  ");
            }
             
        }

        [HttpPut]
        [Route("api/[controller]")]
        public ActionResult<Task> UpdateTask(Task task)
        {
            try
            {
                var updatedTask = _taskRepository.GetTaskById(task.ID);
                if (updatedTask == null)
                {
                    return NotFound("Project TaskID:"+task.ID+" not found to update");
                }
                Task UpdateTask = _taskRepository.UpdateTask(task);                

                return Created(HttpContext.Request.Scheme + "://" +
                 HttpContext.Request.Host + HttpContext.Request.Path + "/" + UpdateTask.ID, updatedTask);
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
            try
            {
                var deletetaskt= _taskRepository.DeleteTaskById(id);
                if (deletetaskt)
                {
                    return Ok("Task Id" + id + " deleted succesfully");
                }
                return StatusCode(409, "Task Id :" + id + "not exists to delete");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Deleting Task data ");
            }
             
        }

    }
}
