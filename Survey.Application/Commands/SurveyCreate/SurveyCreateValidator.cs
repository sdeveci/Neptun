using FluentValidation;

namespace Survey.Application.Commands.SurveyCreate
{
    public class SurveyCreateValidator : AbstractValidator<SurveyCreateCommand>
    {
        public SurveyCreateValidator()
        {
            RuleFor(v => v.Name).NotEmpty();

            RuleFor(v => v.Content)
                .NotEmpty();
        }
    }
}
