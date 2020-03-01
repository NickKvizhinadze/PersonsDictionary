using PersonsDictionary.Application.Cities;
using PersonsDictionary.Persistence.Common;
using PersonsDictionary.Application.Persons;

namespace PersonsDictionary.Persistence.Persons
{
    public class PersonsUow : BaseUow, IPersonsUow
    {
        #region Constructor
        public PersonsUow(
            ApplicationDbContext context,
            IPersonsRepository persons,
            IMobileNumbersRepository mobileNumbers,
            ICitiesRepository cities
            ) : base(context)
        {
            Persons = persons;
            MobileNumbers = mobileNumbers;
            Cities = cities;
        }
        #endregion

        #region Properties
        public IPersonsRepository Persons { get; private set; }
        public IMobileNumbersRepository MobileNumbers { get; private set; }
        public ICitiesRepository Cities { get; private set; }
        #endregion
    }
}
