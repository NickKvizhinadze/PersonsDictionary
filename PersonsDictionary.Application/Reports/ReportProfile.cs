using AutoMapper;
using PersonsDictionary.Domain.Reports;
using PersonsDictionary.Common.Extensions;
using PersonsDictionary.Application.Reports.Models.Dtos;

namespace PersonsDictionary.Application.Reports
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<PersonsRelationCountByType, PersonsRelationsCountByTypeDto>()
                .ForMember(dest => dest.Type, opt => opt.ResolveUsing(src => src.Type.GetDisplayName()));
        }
    }
}
