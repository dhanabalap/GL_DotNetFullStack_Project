using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace GL_DotNetFullStack_Project.Models
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
