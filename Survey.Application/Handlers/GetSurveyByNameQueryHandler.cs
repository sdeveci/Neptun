using AutoMapper;
using MediatR;
using Survey.Application.Queries;
using Survey.Application.Responses;
using Survey.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Handlers
{
    public class GetSurveyByNameQueryHandler : IRequestHandler<GetSurveyByNameQuery, IEnumerable<SurveyResponse>>
    {
        private readonly ISurveyRepository _surveyRespository;
        private readonly IMapper _mapper;

        public GetSurveyByNameQueryHandler(ISurveyRepository surveyRespository, IMapper mapper)
        {
            _surveyRespository = surveyRespository;
            _mapper = mapper;
        }

        
        public async Task<IEnumerable<SurveyResponse>> Handle(GetSurveyByNameQuery request, CancellationToken cancellationToken)
        {
            var surveyList = await _surveyRespository.GetSurveyByName(request.SurveyName);

            var response = _mapper.Map<IEnumerable<SurveyResponse>>(surveyList);

            return response;
        }
    }
}
