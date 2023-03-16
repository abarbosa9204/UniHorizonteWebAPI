using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Models;

using Persistence.Entities;
using Persistence.Repositories.Specifications.User;
using Persistence.Repositories.UserRepository;

namespace Application.Services.Emails.Validator {
  public class EmailsValidator : IEmailsValidators {

    private readonly IGenericRepository<TblUsuario> _repository;

    public EmailsValidator(IGenericRepository<TblUsuario> repository) {
      _repository = repository;
    }

    public async Task<bool> EmailExists(string email) {
      var getByEmailSpecification = new UserByEmailSpecification(email);
      return await _repository.AnyAsync(getByEmailSpecification);
    }

  }
}
