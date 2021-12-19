using System;

namespace GL_DotNetFullStack_Project.Models
{
    public class Project : IBaseEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedOn { get; set; } 
    }
}
