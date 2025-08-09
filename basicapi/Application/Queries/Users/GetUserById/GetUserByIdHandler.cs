using MediatR;
public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdResult?>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserByIdResult?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.Id);

        if (user == null) return null;

        return new GetUserByIdResult(user.Id, user.Name, user.Email);
    }
}
