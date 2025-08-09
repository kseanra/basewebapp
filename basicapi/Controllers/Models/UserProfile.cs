using AutoMapper;
using basicapi.Domain.Entities;
using basicapi.Models;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<GetUserByIdResult, UserResponse>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        CreateMap<UserRequest, User>();
        CreateMap<UserRequest, CreateUserCommand>();
        CreateMap<CreateUserCommand, User>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        CreateMap<User, UserResponse>();    
        CreateMap<GetUsersResult, UsersResponse>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users));
    }
}
