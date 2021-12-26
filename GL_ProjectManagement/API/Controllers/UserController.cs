using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 
using System;
using GL_ProjectManagement.DataAccess.EFCore.Repositories;
using GL_ProjectManagement.BusinessEntities.Models;

namespace GL_ProjectManagement.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseCrudController<User, UserRepository>
    {
        private readonly UserRepository _userRepository;
        public UserController(UserRepository userRepository):base(userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("api/[controller]/{email}/{password}")]
        public IActionResult Get(string email, string password)
        {
            try
            {
                var data = _userRepository.UserLogin(email, password);
                if (!data)
                {
                    return NotFound("Authendication is Failed");
                }
                return Ok("Authendication is Successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in login retrieving data ");
            }

        }
    }
}
