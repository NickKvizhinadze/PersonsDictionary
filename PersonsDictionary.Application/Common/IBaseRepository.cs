using PersonsDictionary.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonsDictionary.Application.Common
{
    public interface IBaseRepository<T, K>
        where T : Entity
        where K : struct
    {

        #region Methods
        T GetById(K id);

        Task<T> GetByIdAsync(K id);

        void Add(T entity);
        
        void AddRange(IEnumerable<T> entities);

        void Update(T entity);

        void Delete(T entity);
        
        void DeleteRange(IEnumerable<T> entities);
        
        #endregion
    }
}
