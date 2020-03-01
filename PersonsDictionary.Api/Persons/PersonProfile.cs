using AutoMapper;
using PersonsDictionary.Api.Persons.Models;
using PersonsDictionary.Application.Persons;

namespace PersonsDictionary.Api.Persons
{
    public class PersonProfile:Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonCreateViewModel, PersonCreateRequest>();
            CreateMap<MobileNumberViewModel, MobileNumberDto>();
        }
    }
}
