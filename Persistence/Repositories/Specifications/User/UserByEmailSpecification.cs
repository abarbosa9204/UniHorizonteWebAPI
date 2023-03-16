using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ardalis.Specification;

using Persistence.Entities;

namespace Persistence.Repositories.Specifications.User {
  public class UserByEmailSpecification : Specification<TblUsuario> {
    public UserByEmailSpecification(string email) {
      Query.Where(user => user.Correo.Equals(email));
    }
  }
}
