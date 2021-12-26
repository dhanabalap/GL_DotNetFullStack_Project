using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 
using System.Collections.Generic;
using System;
using System.Linq;
using GL_ProjectManagement.BusinessEntities.Models;
using GL_ProjectManagement.DataAccess.EFCore.Repositories;

namespace GL_ProjectManagement.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : BaseCrudController<Task, TaskRepository>
    { 

        public TaskController(TaskRepository taskRepository):base(taskRepository)
        {  

        }
         
    }
}
