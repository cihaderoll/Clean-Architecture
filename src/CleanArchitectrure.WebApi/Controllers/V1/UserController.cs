using CleanArchitectrure.Application.UseCases.Users.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectrure.WebApi.Controllers.V1
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;

        public UserController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("validate")]
        public async Task<IActionResult> Validate(CancellationToken ct)
        {
            await _sender.Send(new GetAllUsersQuery { Id = 1});

            return new JsonResult(true);
        }
    }
}
