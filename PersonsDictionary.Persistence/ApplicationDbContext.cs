using Microsoft.EntityFrameworkCore;
using PersonsDictionary.Persistence.Persons;
using PersonsDictionary.Persistence.Cities;

namespace PersonsDictionary.Persistence
{
    public class ApplicationDbContext: DbContext
    {
        #region Fields
        private readonly string _connectionString;

        #endregion

        #region Ctor

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }


        #endregion

        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PersonMapper.Map(modelBuilder);
            PersonRelationMapper.Map(modelBuilder);
            PhoneNumberMapper.Map(modelBuilder);
            CityMapper.Map(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
