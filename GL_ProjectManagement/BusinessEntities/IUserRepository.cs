using System.Collections.Generic;
using System.Threading.Tasks;
using GL_ProjectManagement.BusinessEntities.Models;
using Microsoft.AspNetCore.Mvc;
namespace GL_ProjectManagement.BusinessEntities
{
    public interface IUserRepository: IBaseRepository<User>
    { 
        bool IsUserEmailExist(string email); 
        User UserLogin(string email,string password); 
    }
}
