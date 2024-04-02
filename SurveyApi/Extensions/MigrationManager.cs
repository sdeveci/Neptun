using Microsoft.EntityFrameworkCore;
using Survey.Infrastructure.Data;

namespace SurveyApi.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var surveyContext = scope.ServiceProvider.GetRequiredService<SurveyContext>();

                    if (surveyContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                    {        
                        surveyContext.Database.Migrate();
                    }
                    else
                    {
                        SurveyContextSeed.SeedAsync(surveyContext).Wait();
                    }

                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return host;
        }
    }
}
