using MediatR;
using Survey.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Queries
{
    public class GetSurveyByNameQuery : IRequest<IEnumerable<SurveyResponse>>
    {
        public string SurveyName { get; set; }
        public GetSurveyByNameQuery(string surveyName)
        {
            SurveyName = surveyName;
        }

    }
}
