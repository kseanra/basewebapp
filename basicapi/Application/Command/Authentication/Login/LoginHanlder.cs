using MediatR;
using AutoMapper;
public class LoginHandler : IRequestHandler<LoginCommand, LoginResult>
{
    private readonly ITokenManager _tokenManager;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public LoginHandler(ITokenManager tokenManager, IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        // Initialize the token manager
        _tokenManager = tokenManager;
    }

    public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        // Logic for handling login
        var user = await _userRepository.GetUserByEmailAndPasswordAsync(request?.Email, request?.Password);

        if (user == null)
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        var token = await _tokenManager.GenerateTokenAsync(user);
        return new LoginResult
        {
            AccessToken = token,
            RefreshToken = "generated_refresh_token",
            Expiration = DateTime.UtcNow.AddHours(1)
        };
    }
}