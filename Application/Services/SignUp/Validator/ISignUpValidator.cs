using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.SignUp.Validator
{
    public interface ISignUpValidator
    {
        Task<bool> ValidatePersonId(string personID);

        Task<bool> ValidateEmail(string email);
    }
}
