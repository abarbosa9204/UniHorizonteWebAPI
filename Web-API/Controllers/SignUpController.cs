

using Application.Services.SignUp;

using Domain.Models;
using Domain.Responses.GenericResponses;

using MediatR;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniHorizonte_Web_API.Controllers {
  [EnableCors("AllowAnyOrigins")]
  [ApiController]
  [Route("api/auth/sign-up")]
  public class SignUpController : ControllerBase {

    private readonly IMediator mediator;

    public SignUpController(IMediator mediator) {
      this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> SignUp([FromBody] UserSignUpData body) {
      var request = new SignUpRequest { Body = body };
      var response = await mediator.Send(request);
      return Ok(response);
    }
  }
}
