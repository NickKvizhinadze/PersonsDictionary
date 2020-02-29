using System.Threading.Tasks;
using PersonsDictionary.Application.Common;

namespace PersonsDictionary.Persistence.Common
{
    public class BaseUow : IBaseUow
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public BaseUow(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public int Save()
        {
            return _context.SaveChanges();
        }
        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        #endregion
    }
}
