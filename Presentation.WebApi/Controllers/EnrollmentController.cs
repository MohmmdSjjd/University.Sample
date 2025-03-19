using Application.Dtos.Enrollment;
using Application.Features.Commands.Enrollment.Create;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EnrollmentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<EnrollmentDto>> CreateEnrollment([FromBody] CreateEnrollmentCommand createEnrollmentCommand)
        {
            var enrollment = await _mediator.Send(createEnrollmentCommand);
            return Ok(enrollment);
        }
    }
}
