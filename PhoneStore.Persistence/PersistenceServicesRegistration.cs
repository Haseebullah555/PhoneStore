using PhoneStore.Application.Contracts.Common;
using PhoneStore.Persistence.Repositories.Common;
using PhoneStore.Persistence.Repositories;
using PhoneStore.Persistence.Database;
using PhoneStore.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PhoneStore.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConString")));

            //services.AddIdentity<ApplicationUser, ApplicationRole>()
            //   .AddEntityFrameworkStores<ApplicationDbContext>()
            //   .AddDefaultTokenProviders();


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfwork>();


            return services;
        }
    }
}
