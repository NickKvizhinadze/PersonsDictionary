using Microsoft.EntityFrameworkCore;
using PersonsDictionary.Domain.Persons;

namespace PersonsDictionary.Persistence.Persons
{
    public static class PersonMapper
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Person>().HasKey(e => e.Id);
            modelBuilder.Entity<Person>().Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Person>().Property(e => e.LastName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Person>().Property(e => e.PersonalId).IsRequired().HasMaxLength(11);
            modelBuilder.Entity<Person>().Property(e => e.Gender).IsRequired();
            modelBuilder.Entity<Person>().Property(e => e.BirthDate).IsRequired();
            modelBuilder.Entity<Person>().Property(e => e.CityId).IsRequired();
            modelBuilder.Entity<Person>().HasOne(e => e.City).WithMany(e => e.Persons);
            modelBuilder.Entity<Person>().HasMany(e => e.PhoneNumbers).WithOne(e => e.Person).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Person>().HasMany(e => e.Relations).WithOne(e => e.Person).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Person>().HasMany(e => e.RelatedToRelations).WithOne(e => e.RelatedPerson);
        }
    }
}
