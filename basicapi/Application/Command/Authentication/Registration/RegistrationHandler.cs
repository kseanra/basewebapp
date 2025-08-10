using MediatR;
using AutoMapper;
using basicapi.Domain.Entities;
public class RegistrationHandler : IRequestHandler<RegistrationCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public RegistrationHandler(IUserRepository userRepository, IMapper mapper)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }   

    public async Task Handle(RegistrationCommand request, CancellationToken cancellationToken)
    {
        // Handle registration logic here
        var user = _mapper.Map<User>(request);
        await _userRepository.CreateUserAsync(user);
    }
}
