using System.Collections.Generic;
using System.Linq;
using GL_DotNetFullStack_Project.Data;


namespace GL_DotNetFullStack_Project.Models
{
    public class UserRepoSqlEfImpl : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        private static int count = 100;

        public UserRepoSqlEfImpl(AppDbContext appDbContext)
        {
            _appDbContext= appDbContext;
            
            if (!_appDbContext.Users.Any())
            {
                _appDbContext.Users.Add(new User() { ID = ++count, FirstName = "Sathis", LastName = "T", Email = "sathis@gmail.com", Password = "T123" });
                _appDbContext.Users.Add(new User() { ID = ++count, FirstName = "Sangeetha", LastName = "D", Email = "sangeetha@gmail.com", Password = "D123" });
                _appDbContext.Users.Add(new User() { ID = ++count, FirstName = "Ravi", LastName = "S", Email = "ravi@gmail.com", Password = "S123" });
                _appDbContext.SaveChanges();
            }

        }
        public User CreateUser(User user)
        {
            if (user == null)
            {
                return null;
            }
            else
            {
                user.ID = ++count;
                _appDbContext.Users.Add(user);
                _appDbContext.SaveChanges();
                return user;
            }
        }

        public bool DeleteUserById(int id)
        {
            User deletUser = GetUserByID(id);
            if (deletUser != null)
            {
                _appDbContext.Users.Remove(deletUser);
                _appDbContext.SaveChanges();
                return true;
            }
            return false; 

        }

        public List<User> GetAllUsers()
        { 
            return _appDbContext.Users.ToList();            
        }

        public User GetUserByID(int id)
        {
            return _appDbContext.Users.FirstOrDefault(usr => usr.ID == id);
        }

        public bool IsUserEmailExist(string email)
        {
            User user = _appDbContext.Users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public User UpdateUser(User user)
        {
            User updUser = GetUserByID(user.ID);
            if (updUser == null)
            {
                return null;// NotFound();
            }
             
            updUser.FirstName = user.FirstName;
            updUser.LastName = user.LastName;
            updUser.Email = user.Email;
            updUser.Password = user.Password;

            _appDbContext.Users.Update(updUser);
            _appDbContext.SaveChanges();

            return updUser;
        }

        public bool UserLogin(string email, string password)
        {
            var loginUser = _appDbContext.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (loginUser == null)
            {
                return false;// Unauthorized();
            }

            return true;// Ok();
        }
    }
}
