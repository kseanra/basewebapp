using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using basicapi.Controllers.Models;
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;


    public AuthController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        // Logic for user login
        var command = _mapper.Map<LoginCommand>(request);
        var result = await _mediator.Send(command);
        var tokenResponse = _mapper.Map<TokenResponse>(result);
        return Ok(tokenResponse);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var command = _mapper.Map<RegistrationCommand>(request);
        await _mediator.Send(command);
        return Ok();
    }
}