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

        protected readonly ApplicationDbContext _context;
        private DbSet<T> _entities;

        #endregion

        #region Ctor

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Properties

        private DbSet<T> Entities
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

        protected IQueryable<T> Table
        {
            get { return Entities; }
        }

        protected IQueryable<T> TableNoTracking
        {
            get { return Entities.AsNoTracking(); }
        }

        #endregion

        #region Methods

        public virtual T GetById(K id)
        {
            return Entities.Find(id);
        }

        public virtual async Task<T> GetByIdAsync(K id)
        {
            return await Entities.FindAsync(id);
        }

        public virtual void Add(T entity)
        {
            entity.ThrowIfArgumentNull(nameof(entity));

            Entities.Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            entities.ThrowIfArgumentNull(nameof(entities));

            _context.AddRange(entities);
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void UpdateRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            entity.ThrowIfArgumentNull(nameof(entity));

            Entities.Remove(entity);
        }

        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            entities.ThrowIfArgumentNull(nameof(entities));

            _context.RemoveRange(entities);
        }
        #endregion        
    }
}
