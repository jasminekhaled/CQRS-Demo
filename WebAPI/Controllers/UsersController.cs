using Application.Features.UserFeatures.Commands;
using Application.Features.UserFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/GetUser/{Id}")]
        public async Task<IActionResult> GetUser(int Id)
        {
            return Ok(await _mediator.Send(new GetUserQuery() { Id = Id }));
        }

        [HttpPost]
        [Route("/AddUser")]
        public async Task<IActionResult> AddUser(AddUserCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut]
        [Route("/UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete]
        [Route("/DeleteUser")]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
