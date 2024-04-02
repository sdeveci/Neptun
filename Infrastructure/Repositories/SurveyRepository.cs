using Microsoft.EntityFrameworkCore;
using Survey.Domain.Repositories;
using Survey.Infrastructure.Data;
using Survey.Infrastructure.Repositories.Base;

namespace Survey.Infrastructure.Repositories
{
    public class SurveyRepository : Repository<Domain.Entities.Survey>, ISurveyRepository
    {
        public SurveyRepository(SurveyContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Domain.Entities.Survey>> GetSurveyByName(string surveyName)
        {
            var surveyList = await _dbContext.Surveys
                      .Where(o => o.Name == surveyName)
                      .ToListAsync();

            return surveyList;
        }
    }
}
