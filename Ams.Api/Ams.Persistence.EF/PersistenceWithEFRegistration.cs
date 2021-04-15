using Ams.Persistence.EF.Persistence;
using Ams.Persistence.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ams.Persistence.EF
{
    public static class PersistenceWithEFRegistration
    {
        public static IServiceCollection AddAmsPersistenceEFServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DB_A47B47_ortofoneContext>(options =>
                options.UseSqlServer(configuration.
                GetConnectionString("AmsConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IManagerRepository, ManagerRepository>();
            //services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }
    }
}
