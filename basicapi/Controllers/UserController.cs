using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Dapper.Extensions;
using basicapi.Models;
using MediatR;
using AutoMapper;
using basicapi.Domain.Entities;

namespace basicapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUserById(Guid id = default)
        {
            if (id == default)
            {
                return BadRequest("User ID cannot be empty.");
            }

            var user = await _mediator.Send(new GetUserByIdQuery(id));
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            // Map User to UserResponse using AutoMapper
            var userResponse = _mapper.Map<UserResponse>(user);
            return Ok(userResponse);
        }
        [HttpGet]
        public async Task<ActionResult<UsersResponse>> GetUsers()
        {
            var usersResult = await _mediator.Send(new GetUsersQuery());
            if (usersResult == null || !usersResult.Users.Any())
            {
                return NotFound("No users found.");
            }
            // Map User to UserResponse using AutoMapper
            var userResponses = _mapper.Map<UsersResponse>(usersResult);
            return Ok(userResponses);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] UserRequest userRequest)
        {
            if (userRequest == null || string.IsNullOrEmpty(userRequest.Name))
            {
                return BadRequest("User name cannot be empty.");
            }

            var command = _mapper.Map<CreateUserCommand>(userRequest);
            await _mediator.Send(command);
            return CreatedAtAction(nameof(GetUsers), new { name = userRequest.Name }, userRequest.Name);
        }
    }
}