using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ardalis.Specification;

using Persistence.Entities;

namespace Persistence.Repositories.Specifications.User {
  public class UserByPersonIdSpecification : Specification<TblUsuario> {
    public UserByPersonIdSpecification(string PersonId) {
      Query.Where(user => user.Cedula.Equals(PersonId));
    }
  }
}
