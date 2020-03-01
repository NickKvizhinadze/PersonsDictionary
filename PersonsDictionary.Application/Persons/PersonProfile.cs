using AutoMapper;
using PersonsDictionary.Domain.Persons;

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
