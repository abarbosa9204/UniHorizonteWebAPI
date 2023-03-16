using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Persistence.Contexts;
using Persistence.Repositories.UserRepository;

namespace Persistence {
  public static class ServiceExtension {
    public static void AddDbServices(this IServiceCollection services, IConfiguration configuration) {
      var connectionString = configuration.GetConnectionString("Default");
      Console.WriteLine(connectionString);
      services.AddDbContext<DbUniHorizonteContext>(options => options.UseSqlServer(connectionString));
      services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }

  }
}
