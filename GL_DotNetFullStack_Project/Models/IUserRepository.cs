using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace GL_DotNetFullStack_Project.Models
{
    public interface IUserRepository: IBaseRepository<User>
    { 
        bool IsUserEmailExist(string email); 
        bool UserLogin(string email,string password); 
    }
}
