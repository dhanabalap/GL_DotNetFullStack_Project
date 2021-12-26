using System;
using System.ComponentModel.DataAnnotations;

namespace GL_ProjectManagement.BusinessEntities.Models
{
    public class Project : IBaseEntity
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedOn { get; set; } 
    }
}
