using Microsoft.EntityFrameworkCore;
using T.DataAccess.Data;
using T.DataAccess.Services;
using T.DataAccess.Services.Interfaces;
using T.DataAccess.Services.Interfaces.Entites;
using TechTrial.JWT;

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
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IMetricasService, MetricasService>();
        }
    }
}
