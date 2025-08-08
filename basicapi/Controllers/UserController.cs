using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Dapper.Extensions;
using basicapi.Models;
using MediatR;

namespace basicapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
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
            return Ok(user);
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