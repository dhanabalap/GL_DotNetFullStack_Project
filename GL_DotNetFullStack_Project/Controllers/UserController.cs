using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GL_DotNetFullStack_Project.Models;
using System;

namespace GL_DotNetFullStack_Project.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseCrudController<User, UserRepoSqlEfImpl>
    {
        private readonly UserRepoSqlEfImpl _userRepository;
        public UserController(UserRepoSqlEfImpl userRepository):base(userRepository)
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
