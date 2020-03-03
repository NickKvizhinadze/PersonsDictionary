using AutoMapper;
using PersonsDictionary.Domain.Persons;
using PersonsDictionary.Common.Extensions;
using PersonsDictionary.Application.Persons.Models;

namespace PersonsDictionary.Application.Persons
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonCreateRequest, Person>();
            CreateMap<PhoneNumberDto, PhoneNumber>()
                .ReverseMap();
            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.CityName, opt => opt.ResolveUsing(src => src.City?.Name))
                .ForMember(dest => dest.RelatedPersons, opt => opt.ResolveUsing(src => src.Relations))
                .ForMember(dest => dest.Gender, opt => opt.ResolveUsing(src => src.Gender.GetDisplayName()));

            CreateMap<PersonRelation, RelatedPersonDto>()
                .ForMember(dest => dest.Type, opt => opt.ResolveUsing(src => src.Type.GetDisplayName()))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RelatedPersonId))
                .ForMember(dest => dest.FirstName, opt => opt.ResolveUsing(src => src.RelatedPerson?.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.ResolveUsing(src => src.RelatedPerson?.LastName))
                .ForMember(dest => dest.PersonalId, opt => opt.ResolveUsing(src => src.RelatedPerson?.PersonalId))
                .ForMember(dest => dest.Gender, opt => opt.ResolveUsing(src => src.RelatedPerson?.Gender.GetDisplayName()))
                .ForMember(dest => dest.BirthDate, opt => opt.ResolveUsing(src => src.RelatedPerson?.BirthDate))
                .ForMember(dest => dest.CityId, opt => opt.ResolveUsing(src => src.RelatedPerson?.CityId))
                .ForMember(dest => dest.CityName, opt => opt.ResolveUsing(src => src.RelatedPerson?.City?.Name));
        }
    }
}
