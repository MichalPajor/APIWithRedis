using APIWithRedis.DTOs;
using APIWithRedis.Models;
using AutoMapper;

namespace APIWithRedis.Profiles{
    public class PlatformProfile : Profile{
        public PlatformProfile()
        {
            //Source -> Target
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<PlatformCreateDto, Platform>(); 
            CreateMap<PlatformUpdateDto, Platform>();
        }
    }
}