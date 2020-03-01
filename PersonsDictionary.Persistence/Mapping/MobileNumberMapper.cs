using Microsoft.EntityFrameworkCore;
using PersonsDictionary.Domain.Persons;

namespace PersonsDictionary.Persistence.Mapping
{
    public static class MobileNumberMapper
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MobileNumber>().ToTable("MobileNumbers");
            modelBuilder.Entity<MobileNumber>().HasKey(e => e.Id);
            modelBuilder.Entity<MobileNumber>().Property(e => e.Value).IsRequired().HasMaxLength(20);
        }
    }
}
