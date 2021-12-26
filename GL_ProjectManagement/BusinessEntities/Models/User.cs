using System.ComponentModel.DataAnnotations;

namespace GL_ProjectManagement.BusinessEntities.Models
{
    public class User  :IBaseEntity
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
      
    }
}
