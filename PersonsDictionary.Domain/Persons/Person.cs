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

        public Person(int id, string firstName, string lastName, string personalId, Gender gender, DateTime birthDate, City city)
            : base(id)
        {
            Update(firstName, lastName, personalId, gender, birthDate, city);
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

        public void ManagePhoneNumbers(List<PhoneNumber> phoneNumbers)
        {
            //Deleting numbers

            var phoneToRemove = _phoneNumbers.Where(en => en.Id != 0 && phoneNumbers.All(n => n.Id != en.Id));


            _phoneNumbers.RemoveAll(en => phoneNumbers.All(n => n.Id != en.Id));

            //Updating Numbers
            foreach (var item in phoneNumbers)
            {
                var phoneNumber = _phoneNumbers.SingleOrDefault(n => n.Id == item.Id);
                if (phoneNumber != null)
                {
                    phoneNumber.Type = item.Type;
                    phoneNumber.Value = item.Value;
                }
            }

            var numbersToAdd = phoneNumbers.Where(n => n.Id == 0);
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
