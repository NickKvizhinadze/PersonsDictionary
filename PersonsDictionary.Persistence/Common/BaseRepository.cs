using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PersonsDictionary.Domain.Common;
using PersonsDictionary.Common.Extensions;
using PersonsDictionary.Application.Common;

namespace PersonsDictionary.Persistence.Repositories
{
    public abstract class BaseRepository<T, K> : IBaseRepository<T, K> where T : Entity where K : struct
    {
        #region Fields

        private readonly ApplicationDbContext _context;
        private DbSet<T> _entities;

        #endregion

        #region Ctor

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Properties

        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }

                return _entities;
            }
        }

        private IQueryable<T> Table
        {
            get { return Entities; }
        }

        private IQueryable<T> TableNoTracking
        {
            get { return Entities.AsNoTracking(); }
        }

        #endregion

        #region Methods

        public T GetById(K id)
        {
            return Entities.Find(id);
        }

        public async Task<T> GetByIdAsync(K id)
        {
            return await Entities.FindAsync(id);
        }

        public void Add(T entity)
        {
            entity.ThrowIfArgumentNull(nameof(entity));

            Entities.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            entities.ThrowIfArgumentNull(nameof(entities));

            _context.AddRange(entities);
        }
        
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            entity.ThrowIfArgumentNull(nameof(entity));

            Entities.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            entities.ThrowIfArgumentNull(nameof(entities));

            _context.RemoveRange(entities);
        }
        #endregion        
    }
}
