using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace GL_DotNetFullStack_Project.Models
{
    public class UserRepoImpl : IUserRepository
    {
         static List<User> userList = new List<User>();
         static int count = 100;

        public UserRepoImpl()
        {
            userList.Add(new User() { ID = ++count, FirstName = "Sathis", LastName = "T", Email = "sathis@gmail.com", Password = "T123" });
            userList.Add(new User() { ID = ++count, FirstName = "Sangeetha", LastName = "D", Email = "sangeetha@gmail.com", Password = "D123" });
            userList.Add(new User() { ID = ++count, FirstName = "Ravi", LastName = "S", Email = "ravi@gmail.com", Password = "S123" });
            userList.Add(new User() { ID = ++count, FirstName = "Kiruthik", LastName = "D", Email = "kiruthik@gmail.com", Password = "D123" });
        }
        public User CreateUser(User user)
        {
            var userExists = userList.FirstOrDefault(p => p.ID == user.ID);
           
            if (userExists != null)
            {
                //return StatusCode(409, "UserID already exists");
                return null;
            }
            user.ID = ++count;
            userList.Add(user);
            return user; 
        }

        public List<User> GetAllUsers()
        {
            return userList;    
        }

        public User GetUserByID(int ID)
        {
            var user = userList.FirstOrDefault(u => u.ID == ID);
            return user;    
        }
        public bool IsUserEmailExist(string email)
        {
            var user = userList.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public User UpdateUser(User user)
        {
            var updUser = userList.FirstOrDefault(u => u.ID == user.ID);

            if (updUser == null)
            {
                return null;// NotFound();
            }
            updUser.FirstName = user.FirstName;
            updUser.LastName = user.LastName;
            updUser.Email = user.Email;
            updUser.Password = user.Password;

            return updUser;
        }

        public bool UserLogin(string email,string password)
        {
            var loginUser = userList.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (loginUser == null)
            {
                return false;// Unauthorized();
            }
            return true;// Ok();

        }

        public bool DeleteUserById(int id)
        {
            var deletUser = userList.FirstOrDefault(u => u.ID == id);
            if (deletUser != null) 
            {
                userList.Remove(deletUser);
                return true; 
            }            
            return false;
        }
    }
}
