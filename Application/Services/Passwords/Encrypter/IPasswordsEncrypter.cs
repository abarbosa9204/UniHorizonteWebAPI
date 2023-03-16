using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Passwords.Encrypter {
  public interface IPasswordsEncrypter {
    string GetHashedPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
  }
}
