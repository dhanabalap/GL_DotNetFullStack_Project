using System;
using System.ComponentModel.DataAnnotations;

namespace GL_ProjectManagement.BusinessEntities.Models
{
    public class Task
    {
        public int ID { get; set; }
        [Required]
        public int ProjectID { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public int AssignedToUserID { get; set; }
        [Required]
        public string Detail { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
