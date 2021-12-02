using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GL_DotNetFullStack_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GL_DotNetFullStack_Project.Controllers
{
    
    [ApiController]
    public class ProjectController : ControllerBase
    { 
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository; //Constructor DI pattern
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_projectRepository.GetAllProject());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data ");
            }             
        }
         
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var data = _projectRepository.GetProjectById(id);
                if (data == null)
                {
                    return NotFound("Project Record not Found");
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
        public ActionResult<Project> Post([FromBody] Project project)
        {            
            try
            {
                if (project.Name == null || project.Detail == null)
                {
                    return BadRequest();
                }
                Project prjExist = _projectRepository.GetProjectByName(project.Name);
                //is Already Project Name exist
                if (prjExist != null)
                {
                    return StatusCode(409, "Project :" + project.Name + "already exists");
                }
                 
                Project createdproject = _projectRepository.CreateProject(project);
                //return Ok("New User Created");
                return Created(HttpContext.Request.Scheme + "://" +
                 HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdproject.ID, createdproject);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Creating User data ");
            }             
        }

        [HttpPut]
        [Route("api/[controller]")]
        public ActionResult<Project> Put([FromBody] Project project)
        {
            try
            {
                Project updateproject = _projectRepository.GetProjectById(project.ID); ;
                //is Already user not exist
                if (updateproject == null)
                {
                    return NotFound( "Trying to Updat Project Id :" + project.ID + "not found ");
                    //return new NoContentResult();
                }
                Project updatedProjec= _projectRepository.UpdateProject(project);
                //return new OkResult(); 
                return Created(HttpContext.Request.Scheme + "://" +
                   HttpContext.Request.Host + HttpContext.Request.Path + "/" + updatedProjec.ID, updatedProjec);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Updating Project data ");
            } 
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]        
        public IActionResult DeleteProjectById(int id)
        {
            try
            {
                var prjdeleted = _projectRepository.DeleteProjectById(id);
                if (prjdeleted)
                {
                    return Ok("Project " + id + " deleted succesfully");
                }
                return StatusCode(409, "Project :" + id + "not exists to delete");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Deletig User data ");
            }             
        }
    }
}
