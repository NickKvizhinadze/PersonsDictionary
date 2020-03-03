using PersonsDictionary.Persistence.Common;
using PersonsDictionary.Application.Persons.Abstractions;
using PersonsDictionary.Application.Collections.Abstractions;

namespace PersonsDictionary.Persistence.Collections
{
    public class CollectionsUow : BaseUow, ICollectionsUow
    {
        #region Constructor
        public CollectionsUow(ApplicationDbContext context, IPersonsRepository persons):base(context)
        {
            Persons = persons;
        }
        #endregion

        #region Propertyies
        public IPersonsRepository Persons { get; }
        #endregion

    }
}
