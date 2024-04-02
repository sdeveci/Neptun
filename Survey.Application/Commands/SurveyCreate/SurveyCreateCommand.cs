using MediatR;
using Survey.Application.Responses;

namespace Survey.Application.Commands.SurveyCreate
{
    public class SurveyCreateCommand : IRequest<SurveyResponse>
    {
        public string Name { get; set; }
        public string Content { get; set; } 
        public DateTime CreatedAt { get; set; } 
    }
}
