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

        public UserController(UserRepoSqlEfImpl userRepository):base(userRepository)
        {
            
        }
         
    }
}
