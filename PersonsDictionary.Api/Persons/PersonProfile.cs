using AutoMapper;
using PersonsDictionary.Api.Persons.Models;
using PersonsDictionary.Application.Persons.Models;

namespace PersonsDictionary.Api.Persons
{
    public class PersonProfile:Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonCreateViewModel, PersonCreateRequest>();
            CreateMap<PhoneNumberViewModel, PhoneNumberDto>();
            CreateMap<RelatedPersonCreateViewModel, RelatedPersonCreateRequest>();
        }
    }
}
