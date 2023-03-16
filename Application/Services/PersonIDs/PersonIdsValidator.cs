using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Persistence.Entities;
using Persistence.Repositories.Specifications.User;
using Persistence.Repositories.UserRepository;

namespace Application.Services.PersonIDs {
  public class PersonIdsValidator : IPersonIdsValidator {

    private readonly IGenericRepository<TblUsuario> _repository;

    public PersonIdsValidator(IGenericRepository<TblUsuario> repository) {
      _repository = repository;
    }

    public async Task<bool> PersonIdExists(string PersonId) {
      var getByPersonIdSpecification = new UserByPersonIdSpecification(PersonId);
      return await _repository.AnyAsync(getByPersonIdSpecification);
    }
  }
}
