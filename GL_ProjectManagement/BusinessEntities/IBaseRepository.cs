using GL_ProjectManagement.BusinessEntities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GL_ProjectManagement.BusinessEntities
{
    public interface IBaseRepository<T> where T : class, IBaseEntity
    {
        
        Task<List<T>> Get();
        Task<T> Get(int id);
        Task<int> GetMaxId(T entity);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> DeleteById(int id);
    }
}
