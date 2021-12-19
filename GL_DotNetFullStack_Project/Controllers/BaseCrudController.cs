using GL_DotNetFullStack_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GL_DotNetFullStack_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseCrudController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IBaseEntity
        where TRepository : IBaseRepository<TEntity>
    {
        private readonly TRepository _repository;

        public BaseCrudController(TRepository repository)
        {
            this._repository = repository;
        }

        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            try
            {
                return Ok(await _repository.Get());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data ");
            } 
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            try
            {
                var entity = await _repository.Get(id); 
                if (entity == null)
                {
                    return NotFound("Id :"+ id + " Not Found");
                }
                return Ok(entity);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data ");
            }
              
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TEntity entity)
        {
            try
            {
                if (id != entity.ID)
                    return BadRequest();

                var entityExist = await _repository.Get(id);
                if (entityExist==null)
                    return NotFound(); 
                
                await _repository.Update(entityExist); 
                return NoContent();  
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Updating " + entity.GetType().Name + " id : "+ id+" data. "+e.StackTrace);
            }

        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Create(TEntity entity)
        {
            try
            {
                /*var entityExist = await _repository.Get(entity.ID);
                 if (entityExist != null)
                    return BadRequest("ID :"+ entity.ID+" Already exists");*/

                var maxId = await _repository.GetMaxId(entity); 
                entity.ID = ++maxId;
                await _repository.Add(entity);
                return CreatedAtAction("Get", new { id = entity.ID }, entity);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Creating data. "+e);
            }
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            try
            {
                var deletedentity = await _repository.DeleteById(id);
                if (deletedentity != null)
                {
                    return Ok(deletedentity);
                }
                return StatusCode(409, " Id :" + id + " not exists to delete");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Deleting id:"+ id+" data ");
            }  
             
        }
         
    }
}
