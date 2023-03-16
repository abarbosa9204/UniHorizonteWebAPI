using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Models;

namespace Application.Services.Tokens.TokenGenerator
{
    public interface ITokenGenerator
    {
        string GenerateToken(UserCredential credentials);
    }
}
