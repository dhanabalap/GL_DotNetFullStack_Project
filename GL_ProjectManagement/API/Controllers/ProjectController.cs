using GL_ProjectManagement.BusinessEntities.Models;
using GL_ProjectManagement.DataAccess.EFCore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GL_ProjectManagement.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : BaseCrudController<Project,ProjectRepository>
    {
        private readonly ProjectRepository _projectRepository;
        public ProjectController(ProjectRepository repository) : base(repository)
        {
            _projectRepository=repository;
        }
       /*
        // POST: api/[controller]
        [HttpPost]
        public  async Task<ActionResult<Project>> Create(Project entity)
        {
            try
            {
                if (entity.Name == null || entity.Detail == null)
                {
                    return BadRequest();
                }
                var prjExist = _projectRepository.Get(entity.ID);
                //is Already Project Name exist
                if (prjExist != null)
                {
                    return StatusCode(409, "Project :" + entity.ID + "already exists");
                }
                await _projectRepository.Add(entity);
                return CreatedAtAction("Get", new { id = entity.ID }, entity);
                //   return Created(HttpContext.Request.Scheme + "://" +
                //    HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdproject.ID, createdproject);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Creating " + entity.ToString() + " data ");
            }            
              
        }
        /*
        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public  async Task<IActionResult> Update(int id, Project entity)
        {
            try
            {
                if (id != entity.ID)
                    return BadRequest();

                if (entity.Name == null || entity.Detail == null)                 
                    return BadRequest(); 

                var entityExist = await _projectRepository.Get(id);
                if (entityExist == null) 
                    return NotFound("Trying to Updat Project Id :" + entity.ID + "not found ");

                await _projectRepository.Update(entity);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Updating " + entity.ToString() + " data ");
            }

        }
        */
         
         
    }
}
