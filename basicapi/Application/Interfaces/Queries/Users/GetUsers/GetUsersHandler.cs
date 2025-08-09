using MediatR;
using System.Collections.Generic;

public class GetUsersHandler : IRequestHandler<GetUsersQuery, GetUsersResult>
{
    private readonly IUserRepository _userRepository;

    public GetUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUsersResult> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllUsersAsync();
        return new GetUsersResult { Users = users };
    }
}