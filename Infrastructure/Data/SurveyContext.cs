using Microsoft.EntityFrameworkCore;

namespace Survey.Infrastructure.Data
{
    public class SurveyContext : DbContext
    {
        public SurveyContext(DbContextOptions<SurveyContext> options) : base(options)
        {

        }
        public DbSet<Domain.Entities.Survey> Surveys { get; set; }
    }
}
