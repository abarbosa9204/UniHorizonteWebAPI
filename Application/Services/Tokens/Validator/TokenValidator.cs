using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services.Tokens.Validator
{
    public class TokenValidator: ITokenValidator {
    private readonly string secretKey;

    public TokenValidator(IConfiguration configuration) {
      secretKey = configuration.GetSection("SecretKey").Value ?? string.Empty;
    }

    public ClaimsPrincipal? ValidateToken(string token) {
      var tokenHandler = new JwtSecurityTokenHandler();
      
      var key = Encoding.ASCII.GetBytes(secretKey);

      var validationParameters = new TokenValidationParameters {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
      };

      try {
        var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
        if(validatedToken is JwtSecurityToken jwtSecurityToken
          && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase)) {
          return principal;
        } else {
          return null;
        }
      } catch(Exception) {
        throw new Exception("Token Invalido");
      }
    }
  }



}