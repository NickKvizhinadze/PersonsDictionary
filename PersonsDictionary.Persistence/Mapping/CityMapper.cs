using Microsoft.EntityFrameworkCore;
using PersonsDictionary.Domain.Persons;

namespace PersonsDictionary.Persistence.Mapping
{
    public static class CityMapper
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().ToTable("Cities");
            modelBuilder.Entity<City>().HasKey(e => e.Id);
            modelBuilder.Entity<City>().Property(e => e.Name).IsRequired().HasMaxLength(50);
        }
    }
}
