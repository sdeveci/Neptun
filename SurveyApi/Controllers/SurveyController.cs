using MediatR;
using Microsoft.AspNetCore.Mvc;
using Survey.Application.Commands.SurveyCreate;
using Survey.Application.Queries;
using Survey.Application.Responses;
using System.Net;

namespace SurveyApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SurveyController> _logger;

        public SurveyController(IMediator mediator, ILogger<SurveyController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("GetSurveyByName/{surveyName}")]
        [ProducesResponseType(typeof(IEnumerable<SurveyResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<SurveyResponse>>> GetSurveyByName(string surveyName)
        {
            var query = new GetSurveyByNameQuery(surveyName);

            var surveyList = await _mediator.Send(query);
            if (surveyList.Count() == decimal.Zero)
                return NotFound();

            return Ok(surveyList);
        }

        [HttpPost]
        [ProducesResponseType(typeof(SurveyResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SurveyResponse>> OrderCreate([FromBody] SurveyCreateCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
