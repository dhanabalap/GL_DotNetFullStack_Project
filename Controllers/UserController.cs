using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GL_DotNetFullStack_Project.Models;
using System;

namespace GL_DotNetFullStack_Project.Controllers
{

    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository; //DI pattern
            /* For better separate of concern  -Avoid this approach as this class should not be creating depedent class  instance/object
             instead use IOC container to register service use Constructor Depecy Injection
              concern _userRepository = new UserRepoImpl(); */
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_userRepository.GetAllUsers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data ");
            }

        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var data = _userRepository.GetUserByID(id);
                if (data == null)
                {
                    return NotFound("Record not Found");
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
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                if (user.FirstName == null || user.LastName == null || user.Email == null || user.Password == null)
                {
                    return BadRequest();
                }
                var userexist = _userRepository.IsUserEmailExist(user.Email);
                //is Already user exist
                if (userexist)
                {
                    return StatusCode(409, "User with Email :" + user.Email + "already exists");
                }

                var createduser = _userRepository.CreateUser(user);
                //return Ok("New User Created");
                return Created(HttpContext.Request.Scheme + "://" +
                 HttpContext.Request.Host + HttpContext.Request.Path + "/" + user.ID, user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Creating User data ");
            }

        }

        [HttpPut]
        [Route("api/[controller]")]
        public IActionResult Put([FromBody] User user)
        {
            try
            {
                var userexist = _userRepository.GetUserByID(user.ID); ;
                //is Already user not exist
                if (userexist == null)
                {
                    return StatusCode(409, "User UserId :" + user.ID + "not  exists");
                    //return new NoContentResult();
                }
                var updObj = _userRepository.UpdateUser(user);
                //return new OkResult(); 
                return Created(HttpContext.Request.Scheme + "://" +
                   HttpContext.Request.Host + HttpContext.Request.Path + "/" + user.ID, user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Updating User data ");
            }

        }
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var userdeleted = _userRepository.DeleteUserById(id);
                if (userdeleted)
                    return Ok();
                return StatusCode(409, "User UserId :" + id + "not exists");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Updating User data ");
            }
        }

        [HttpGet]
        [Route("api/[controller]/{email}/{password}")]
        public IActionResult Get(string email,string password)
        {
            try
            {
                var data = _userRepository.UserLogin(email,password);
                if (!data)
                {
                    return NotFound("Record not Found"); 
                }
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in login retrieving data ");
            }

        }


    }
}
