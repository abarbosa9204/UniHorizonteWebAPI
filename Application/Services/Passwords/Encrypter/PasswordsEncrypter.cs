using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BCryptNet = BCrypt.Net.BCrypt;

namespace Application.Services.Passwords.Encrypter {
  public class PasswordsEncrypter: IPasswordsEncrypter {

    public string GetHashedPassword(string password) {
      string salt = BCryptNet.GenerateSalt();
      string hashedPassword = BCryptNet.HashPassword(password, salt);
      return hashedPassword;
    }

    public bool VerifyPassword(string password, string hashedPassword) {
      bool passwordMatch = BCryptNet.Verify(password, hashedPassword);
      return passwordMatch;
    }

  }
}
