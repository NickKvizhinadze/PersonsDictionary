using AutoMapper;
using PersonsDictionary.Domain.Persons;
using PersonsDictionary.Application.Persons.Models;

namespace PersonsDictionary.Application.Persons
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonCreateRequest, Person>();                
            CreateMap<PhoneNumberDto, PhoneNumber>(); 
        }
    }
}
