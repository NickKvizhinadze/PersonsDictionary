using Microsoft.EntityFrameworkCore;
using PersonsDictionary.Domain.Persons;

namespace PersonsDictionary.Persistence.Persons
{
    public static class PhoneNumberMapper
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneNumber>().ToTable("PhoneNumbers");
            modelBuilder.Entity<PhoneNumber>().HasKey(e => e.Id);
            modelBuilder.Entity<PhoneNumber>().Property(e => e.Value).IsRequired().HasMaxLength(20);
        }
    }
}
