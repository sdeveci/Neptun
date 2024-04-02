using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Survey.Domain.Repositories;
using Survey.Domain.Repositories.Base;
using Survey.Infrastructure.Data;
using Survey.Infrastructure.Repositories;
using Survey.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
namespace Survey.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            //services.AddDbContext<OrderContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"),
            //                                    ServiceLifetime.Singleton,
            //                                    ServiceLifetime.Singleton);


            services.AddDbContext<SurveyContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("ScoopyConnection"),
                    b => b.MigrationsAssembly(typeof(SurveyContext).Assembly.FullName)), ServiceLifetime.Singleton);

            //Add Repositories
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ISurveyRepository, SurveyRepository>();

            return services;
        }
    }
}
