using Microsoft.EntityFrameworkCore;
using T.DataAccess.Data;
using T.DataAccess.Services;
using T.DataAccess.Services.Interfaces;

namespace TechTrial.IOC
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TechTrialContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("TechTrialConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
