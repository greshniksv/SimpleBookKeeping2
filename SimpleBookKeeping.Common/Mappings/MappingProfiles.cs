using System.Linq;
using AutoMapper;
using SimpleBookKeeping.Common.DTOs;
using SimpleBookKeeping.Database.Models;

namespace SimpleBookKeeping.Common.Mappings
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<PlanDto, Plan>().ReverseMap()
                .ForMember(dst => dst.UserMembers,
                    opt => opt.MapFrom(src => src.PlanMembers.Select(x => x.Id).ToList()));
        }
    }
}
