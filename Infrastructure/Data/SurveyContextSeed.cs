using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Infrastructure.Data
{
    public class SurveyContextSeed
    {
        public static async Task SeedAsync(SurveyContext surveyContext)
        {
            if (!surveyContext.Surveys.Any())
            {
                surveyContext.Surveys.AddRange(GetPreconfiguredSurveys());

                await surveyContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<Domain.Entities.Survey> GetPreconfiguredSurveys()
        {
            return new List<Domain.Entities.Survey>()
            {
               new Domain.Entities.Survey()
               {
                   Name = Guid.NewGuid().ToString(),
                   Content = Guid.NewGuid().ToString(),                   
                   CreatedAt = DateTime.UtcNow
               },
               new Domain.Entities.Survey()
               {
                   Name = Guid.NewGuid().ToString(),
                   Content = Guid.NewGuid().ToString(),
                   CreatedAt = DateTime.UtcNow
               },
               new Domain.Entities.Survey()
               {
                   Name = Guid.NewGuid().ToString(),
                   Content = Guid.NewGuid().ToString(),
                   CreatedAt = DateTime.UtcNow
               }
            };
        }
    }
}
