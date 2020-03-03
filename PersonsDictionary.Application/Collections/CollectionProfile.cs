using AutoMapper;
using System.Collections.Generic;
using PersonsDictionary.Application.Collections.Models;

namespace PersonsDictionary.Application.Collections
{
    public class CollectionProfile: Profile
    {
        public CollectionProfile()
        {
            CreateMap<KeyValuePair<int, string>, CollectionDto<int>>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Key))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Value));
        }   
    }
}
