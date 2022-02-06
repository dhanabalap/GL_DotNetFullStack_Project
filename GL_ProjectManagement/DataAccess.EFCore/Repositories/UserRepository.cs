using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using GL_ProjectManagement.BusinessEntities.Models;
using GL_ProjectManagement.DataAccess.EFCore.Repositories;

using Microsoft.EntityFrameworkCore;

namespace GL_ProjectManagement.DataAccess.EFCore.Repositories
{
    public class UserRepository : BaseRepository<User, AppDbContext>
    {
        private readonly AppDbContext _appDbContext;
        private static int count = 100;

        public UserRepository(AppDbContext appDbContext):base(appDbContext)
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
         
        public User UserLogin(string email, string password)
        { 
              User loginUser=_appDbContext.Users.FirstOrDefault<User>(x => x.Email == email);
             if (loginUser.ID ==0)
            {
                return null;
            }
            return loginUser;

        }
       /*
          * public new async Task<User> Update(User entity)
        {
            var updEntity = await _appDbContext.Set<User>().FindAsync(entity.ID); 
            //_appDbContext.Projects.FirstOrDefault(p => p.ID == entity.ID);
            if (updEntity != null)
            {
                updEntity.FirstName = entity.FirstName;
                updEntity.LastName = entity.LastName;
                updEntity.Email = entity.Email;
                updEntity.Password = entity.Password;

                _appDbContext.Entry(updEntity).State = EntityState.Modified;
                await _appDbContext.SaveChangesAsync();
                return updEntity;
            }
            return null;
        }
            
        */

    }
}
