using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ardalis.Specification.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;

using Persistence.Contexts;
using Persistence.Entities;

namespace Persistence.Repositories.UserRepository {
  public class GenericRepository<T> : RepositoryBase<T>, IGenericRepository<T> where T : class {
    public GenericRepository(DbUniHorizonteContext dbContext) : base(dbContext) { }

  }
}
