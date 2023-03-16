using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Services.Passwords.Encrypter;

using Ardalis.Specification;

using Domain.DTO;

using Persistence.Entities;
using Persistence.Repositories.Specifications.User;
using Persistence.Repositories.UserRepository;

namespace Application.Services.Passwords.Validator {
  public class PasswordsValidator : IPasswordsValidator {

    private readonly IGenericRepository<TblUsuario> _repository;
    private readonly IPasswordsEncrypter _passwordEncrypter;

    public PasswordsValidator(IGenericRepository<TblUsuario> repository, IPasswordsEncrypter passwordsEncrypter) {
      _repository = repository;
      _passwordEncrypter = passwordsEncrypter;
    }

    public async Task<bool> checkPassword(SignInData signInData) {
      var getByEmailSpecification = new UserByEmailSpecification(signInData.Email);
      var user = await _repository.FirstOrDefaultAsync(getByEmailSpecification);
      return user != null && _passwordEncrypter.VerifyPassword(signInData.Password, user.Password);
    }
  }
}
