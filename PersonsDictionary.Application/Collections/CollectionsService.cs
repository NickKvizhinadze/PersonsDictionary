using AutoMapper;
using PersonsDictionary.Application.Collections.Abstractions;
using PersonsDictionary.Application.Collections.Models;
using PersonsDictionary.Common.Extensions;
using PersonsDictionary.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsDictionary.Application.Collections
{
    public class CollectionsService : ICollectionsService
    {

        #region Fields
        private readonly ICollectionsUow _uow;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public CollectionsService(ICollectionsUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<List<CollectionDto<int>>> GetPersonsAsync()
        {
            var persons = await _uow.Persons.GetPersonsCollectionAsync();
            return _mapper.Map<List<CollectionDto<int>>>(persons);
        }

        public List<CollectionDto<int>> GetGenders()
        {
            var genders = typeof(Gender).ToCollection<Gender>();
            return _mapper.Map<List<CollectionDto<int>>>(genders);
        }

        public List<CollectionDto<int>> GetPhoneNumberTypes()
        {
            var genders = typeof(PhoneNumberType).ToCollection<PhoneNumberType>();
            return _mapper.Map<List<CollectionDto<int>>>(genders);
        }

        public List<CollectionDto<int>> GetPersonRelationTypes()
        {
            var genders = typeof(PersonRelationType).ToCollection<PersonRelationType>();
            return _mapper.Map<List<CollectionDto<int>>>(genders);
        }
        #endregion
    }
}
