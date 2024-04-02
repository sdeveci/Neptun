using AutoMapper;
using Survey.Application.Commands.SurveyCreate;
using Survey.Application.Responses;


namespace Survey.Application.Mapper
{
    public class SurveyMappingProfile : Profile
    {
        public SurveyMappingProfile()
        {
            CreateMap<Domain.Entities.Survey, SurveyCreateCommand>().ReverseMap();
            CreateMap<Domain.Entities.Survey, SurveyResponse>().ReverseMap();
        }
    }
}
