using Application.Services.SignIn;

using Domain.DTO;

using MediatR;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace UniHorizonte_Web_API.Controllers {
  [ApiController]
  [Route("/api/auth/sign-in")]
  [EnableCors("AllowAnyOrigins")]
  public class SignInController : ControllerBase {

    private readonly IMediator mediator;

    public SignInController(IMediator mediator) {
      this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> SignIn([FromBody] SignInData Body) {
      var request = new SignInRequest { Body = Body };
      return Ok(await mediator.Send(request));
    }
  }
}
