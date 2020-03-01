using PersonsDictionary.Application.Cities;
using PersonsDictionary.Persistence.Common;
using PersonsDictionary.Application.Persons.Abstractions;

namespace PersonsDictionary.Persistence.Persons
{
    public class PersonsUow : BaseUow, IPersonsUow
    {
        #region Constructor
        public PersonsUow(
            ApplicationDbContext context,
            IPersonsRepository persons,
            IPersonRelationsRepository personRelations,
            IPhoneNumbersRepository mobileNumbers,
            ICitiesRepository cities
            ) : base(context)
        {
            Persons = persons;
            PersonRelations = personRelations;
            PhoneNumbers = mobileNumbers;
            Cities = cities;
        }
        #endregion

        #region Properties
        public IPersonsRepository Persons { get; private set; }
        public IPersonRelationsRepository PersonRelations { get; private set; }
        public IPhoneNumbersRepository PhoneNumbers { get; private set; }
        public ICitiesRepository Cities { get; private set; }
        #endregion
    }
}
