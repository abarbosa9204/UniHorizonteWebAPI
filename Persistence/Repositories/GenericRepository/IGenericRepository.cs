using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ardalis.Specification;

using Persistence.Entities;

namespace Persistence.Repositories.UserRepository {
  public interface IGenericRepository<T> : IRepositoryBase<T> where T : class { }
}
