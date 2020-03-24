using System;
using System.Linq;
using System.Collections.Generic;
using PersonsDictionary.Domain.Enums;
using PersonsDictionary.Domain.Common;
using PersonsDictionary.Domain.Cities;
using PersonsDictionary.Common.Models;
using PersonsDictionary.Localization;

namespace PersonsDictionary.Domain.Persons
{
    public class Person : Entity
    {
        #region Fields
        private readonly List<PersonRelation> _relations = new List<PersonRelation>();
        private readonly List<PhoneNumber> _phoneNumbers = new List<PhoneNumber>();
        #endregion

        #region Constructor
        private Person()
        {
        }

        public Person(string firstName, string lastName, string personalId, Gender gender, DateTime birthDate, City city, List<PhoneNumber> phoneNumbers)
        //: base(id)
        {
            Update(firstName, lastName, personalId, gender, birthDate, city);
            _phoneNumbers.AddRange(phoneNumbers);
        }
        #endregion

        #region Properties
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PersonalId { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string ImageUrl { get; private set; }
        #endregion

        #region Navigation Properties
        public IReadOnlyList<PhoneNumber> PhoneNumbers => _phoneNumbers.ToList();
        public IReadOnlyList<PersonRelation> Relations => _relations.ToList();
        public City City { get; private set; }
        #endregion

        #region Methods
        public void AddImage(string url)
        {
            ImageUrl = url;
        }

        public Result AddRelation(PersonRelationType type, Person relatedPerson)
        {
            var result = new Result();
            if (_relations.Any(r => r.RelatedPerson.Id == relatedPerson.Id))
            {
                result.AddError(ErrorMessages.SuchRelationAlreadyExists);
                return result;
            }

            var relation = new PersonRelation(type, this, relatedPerson);
            _relations.Add(relation);
            return result;
        }

        public void ManagePhoneNumbers(List<PhoneNumber> newPhoneNumbers)
        {

            //Deleting numbers
            _phoneNumbers.RemoveAll(en => newPhoneNumbers.All(n => n.Id != en.Id));

            //Updating Numbers
            foreach (var item in newPhoneNumbers)
            {
                var phoneNumber = _phoneNumbers.SingleOrDefault(n => n.Id == item.Id);
                if (phoneNumber != null)
                    phoneNumber.Update(item.Type, item.Value);
            }

            var numbersToAdd = newPhoneNumbers.Where(n => n.Id == 0);
            if (numbersToAdd.Any())
                _phoneNumbers.AddRange(numbersToAdd);
        }

        public void Update(string firstName, string lastName, string personalId, Gender gender, DateTime birthDate, City city)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalId = personalId;
            Gender = gender;
            BirthDate = birthDate;
            City = city;
        }
        #endregion
    }
}
