using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Emails.Validator {
  public interface IEmailsValidators {
    public Task<bool> EmailExists(string email);
  }
}
