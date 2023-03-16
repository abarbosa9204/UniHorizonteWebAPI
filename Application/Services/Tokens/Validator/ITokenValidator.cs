using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Tokens.Validator {
  public interface ITokenValidator {
    ClaimsPrincipal? ValidateToken(string token);
  }
}
