using AutoMapper;
using basicapi.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Map User → UserDto (same property names map automatically)
        CreateMap<GetUserByIdResult, UserResponse>();

        // You can also do custom mapping if names differ:
        // CreateMap<User, UserDto>()
        //     .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName.ToUpper()));
    }
}
