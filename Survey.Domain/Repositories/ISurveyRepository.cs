using Survey.Domain.Repositories.Base;
using Survey.Domain.Entities;
namespace Survey.Domain.Repositories
{
    public  interface ISurveyRepository : IRepository<Survey.Domain.Entities.Survey>
    {
        Task<IEnumerable<Survey.Domain.Entities.Survey>> GetSurveyByName(string surveyName);
    }
}
