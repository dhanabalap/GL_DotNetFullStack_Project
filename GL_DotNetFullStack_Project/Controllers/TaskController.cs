using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GL_DotNetFullStack_Project.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace GL_DotNetFullStack_Project.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : BaseCrudController<Task, TaskRepoSqlEFImpl>
    { 

        public TaskController(TaskRepoSqlEFImpl taskRepository):base(taskRepository)
        {  

        }
         
    }
}
