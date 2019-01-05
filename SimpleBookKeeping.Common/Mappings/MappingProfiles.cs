using AutoMapper;
using Common.DTOs;
using Database.Models;

namespace Common.Mappings
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
