using Microsoft.EntityFrameworkCore;
using PersonsDictionary.Domain.Persons;

namespace PersonsDictionary.Persistence.Persons
{
    public static class PersonRelationMapper
    {
        public static void Map(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PersonRelation>().ToTable("PersonRelations");
            modelBuilder.Entity<PersonRelation>().HasKey(e => e.Id);
        }
    }
}
