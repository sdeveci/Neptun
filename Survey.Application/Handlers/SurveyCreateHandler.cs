using AutoMapper;
using MediatR;
using Survey.Application.Commands.SurveyCreate;
using Survey.Application.Responses;
using Survey.Domain.Repositories;

namespace Survey.Application.Handlers
{
    public class SurveyCreateHandler : IRequestHandler <SurveyCreateCommand,SurveyResponse>
    {
        private readonly ISurveyRepository _surveyRespository;
        private readonly IMapper _mapper;

        public SurveyCreateHandler(ISurveyRepository surveyRespository, IMapper mapper)
        {
            _surveyRespository = surveyRespository;
            _mapper = mapper;
        }

        public async Task<SurveyResponse> Handle(SurveyCreateCommand request, CancellationToken cancellationToken)
        {
            var surveyEntity = _mapper.Map<Domain.Entities.Survey>(request);
            if (surveyEntity == null)
                throw new ApplicationException("Entity could not be mapped!");

            var survey = await _surveyRespository.AddAsync(surveyEntity);

            var surveyResponse = _mapper.Map<SurveyResponse>(survey);

            return surveyResponse;
        }
    }
}
