using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.DTO;

namespace Application.Services.Passwords.Validator {
  public interface IPasswordsValidator {
    Task<bool> checkPassword(SignInData signInData);
  }
}
