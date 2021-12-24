using System.Collections.Generic;
using GL_DotNetFullStack_Project.BusinessEntities.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace GL_DotNetFullStack_Project.BusinessEntities
{
    public interface IUserRepository
    {
        //Task<ActionResult<User>> CreateUser(User user);
        User CreateUser(User user);
        List<User> GetAllUsers();
        bool IsUserEmailExist(string email);
        User GetUserByID(int ID);
        User UpdateUser(User user);
        bool UserLogin(string email,string password);
        bool DeleteUserById(int ID);
    }
}
