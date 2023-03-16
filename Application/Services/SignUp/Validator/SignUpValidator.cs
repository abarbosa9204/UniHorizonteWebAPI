using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Services.Emails.Validator;
using Application.Services.PersonIDs;
using Application.Wrappers;

using Domain.Models;

using Persistence.Entities;
using Persistence.Repositories.Specifications.User;
using Persistence.Repositories.UserRepository;

namespace Application.Services.SignUp.Validator {
  public class SignUpValidator : ISignUpValidator {

    private readonly IPersonIdsValidator personIdsValidator;
    private readonly IEmailsValidators emailsValidators;

    public SignUpValidator(IPersonIdsValidator personIdsValidator, IEmailsValidators emailsValidators) {
      this.personIdsValidator = personIdsValidator;
      this.emailsValidators = emailsValidators;
    }

    public async Task<bool> ValidatePersonId(string personID) {
      return await personIdsValidator.PersonIdExists(personID);
    }

    public async Task<bool> ValidateEmail(string email) {
      return await emailsValidators.EmailExists(email);
    }

  }
}
