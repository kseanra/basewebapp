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
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            // Map User to UserResponse using AutoMapper
            var userResponse = _mapper.Map<UserResponse>(user);
            return Ok(userResponse);
        }
        [HttpGet]
        public async Task<ActionResult<UsersResponse>> GetUsers()
        {
            var usersResult = await _mediator.Send(new GetUsersQuery());
            // Map User to UserResponse using AutoMapper
            var userResponses = _mapper.Map<UsersResponse>(usersResult);
            return Ok(userResponses);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] UserRequest userRequest)
        {
            var command = _mapper.Map<CreateUserCommand>(userRequest);
            await _mediator.Send(command);
            return CreatedAtAction(nameof(GetUsers), new { name = userRequest.Name }, userRequest.Name);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult> UpdateUser(Guid userId, [FromBody] UserRequest userRequest)
        {
        
            var command = _mapper.Map<UpdateUserCommand>(userRequest) with { UserId = userId };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return NoContent();
        }
    }
}