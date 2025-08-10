using AutoMapper;
using basicapi.Controllers.Models;
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
        CreateMap<User, GetUserByIdResult>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        CreateMap<UserRequest, User>();
        CreateMap<UserRequest, CreateUserCommand>();
        CreateMap<UserRequest, UpdateUserCommand>();
        CreateMap<CreateUserCommand, User>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        CreateMap<User, UserResponse>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
        CreateMap<GetUsersResult, UsersResponse>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users));

        CreateMap<RegisterRequest, RegistrationCommand>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        CreateMap<RegistrationCommand, User>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        CreateMap<LoginRequest, LoginCommand>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        CreateMap<LoginResult, TokenResponse>()
            .ForMember(dest => dest.AccessToken, opt => opt.MapFrom(src => src.AccessToken))
            .ForMember(dest => dest.RefreshToken, opt => opt.MapFrom(src => src.RefreshToken))
            .ForMember(dest => dest.Expiration, opt => opt.MapFrom(src => src.Expiration));
    }
}
