using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Dapper.Extensions;
using basicapi.Models;
using MediatR;
using AutoMapper;

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
        public ActionResult<UserResponse> GetUserById(Guid id  = default)
        {
            if (id == default)
            {
                return BadRequest("User ID cannot be empty.");
            }

            var user = _mediator.Send(new GetUserByIdQuery(id)).Result;
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            // Map User to UserResponse using AutoMapper
            var userResponse = _mapper.Map<UserResponse>(user);
            return Ok(userResponse);
        }
        [HttpGet]
        public ActionResult<IEnumerable<UserResponse>> GetUsers()
        {
            return Ok(new List<UserResponse>());
        }

        [HttpPost]
        public ActionResult CreateUser([FromBody] UserRequest userRequest)
        {
            if (userRequest == null || string.IsNullOrEmpty(userRequest.Name))
            {
                return BadRequest("User name cannot be empty.");
            }
            return CreatedAtAction(nameof(GetUsers), new { name = userRequest.Name }, userRequest.Name);
        }
    }
}