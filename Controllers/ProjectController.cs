using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GL_DotNetFullStack_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GL_DotNetFullStack_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private static int count = 0;
        static List<Project> projectList = new List<Project>
        {
            new Project{ID=++count,Name="C# Project", Detail ="Detail for project 1",CreatedOn=DateTime.Now},
            new Project{ID=++count,Name="ASP Core Project", Detail ="Detail for project 2",CreatedOn=DateTime.Now},
            new Project{ID=++count,Name="ASP Core API Project", Detail ="Detail for project 3",CreatedOn=DateTime.Now},
            new Project{ID=++count,Name="Project 4", Detail ="Detail for project 4",CreatedOn=DateTime.Now},
        };


        [HttpGet]
        public List<Project> GetAllProjects()
        {
            return  projectList;
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Project> GetProjectByID(int id)
        {
           try{
                var requestedProject = projectList.FirstOrDefault(p => p.ID == id);
                if (requestedProject == null)
                {
                    return NotFound("Project Id not Found");
                }
                return Ok(requestedProject);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data ");
            }
        }                

        [HttpPost]
        public ActionResult<Project> CreateProject(Project project)
        {
            try
            { if (project.Name == null || project.Detail == null)
                {
                    return BadRequest();
                }
                var projectIdExists = projectList.FirstOrDefault(p => p.ID == project.ID);
                if (projectIdExists != null)
                {
                    return StatusCode(409, "ProjectID already exists");
                }
                project.ID = ++count;
                project.CreatedOn = DateTime.Now;
                projectList.Add(project);
                //return Ok();
                return Created(HttpContext.Request.Scheme + "://" +
                HttpContext.Request.Host + HttpContext.Request.Path + "/" + project.ID, project);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating project data ");
            }
        }

        [HttpPut]
        public ActionResult<Project> UpdateProject(Project project)
        {
            try
            {
                var updatedProject = projectList.FirstOrDefault(p => p.ID == project.ID);

                if (updatedProject == null)
                {
                    return NotFound("Project ID:" + project.ID + " Not Found to update");
                }
                updatedProject.Name = project.Name;
                updatedProject.Detail = project.Detail;

                return Ok(updatedProject);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Updating data ");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProjectById(int id)
        {
            var deletProject = projectList.FirstOrDefault(p => p.ID == id);
            if (deletProject != null)
            {
                projectList.Remove(deletProject);
                return Ok("Project Delete sucessfully");
            }
            return NotFound("Project ID:" + id + " Not Found to Delete"); ;
        }
    }
}
