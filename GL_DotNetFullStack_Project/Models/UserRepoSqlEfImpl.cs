using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GL_DotNetFullStack_Project.Data;
using Microsoft.EntityFrameworkCore;

namespace GL_DotNetFullStack_Project.Models
{
    public class UserRepoSqlEfImpl : BaseEfCoreRepository<User, AppDbContext>
    {
        private readonly AppDbContext _appDbContext;
        private static int count = 100;

        public UserRepoSqlEfImpl(AppDbContext appDbContext):base(appDbContext)
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
         
        public bool UserLogin(string email, string password)
        {
            var loginUser = _appDbContext.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (loginUser == null)
            {
                return false;// Unauthorized();
            }

            return true;// Ok();
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
