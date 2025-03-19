using Application.Features.Commands.Course.Create;
using Application.Features.Commands.Course.Delete;
using Application.Features.Commands.Course.Update;
using Application.Features.Queries.Course.GetByCode;
using Application.Features.Queries.Course.GetByName;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetCourseByName( [FromQuery] GetCourseByNameQuery query)
        {
            return Ok(await _mediator.Send(query));
        } 
        [HttpGet("code")]   
        public async Task<IActionResult> GetCourseByCode( [FromQuery] GetCourseByCodeQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);  
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCourse([FromBody] DeleteCourseCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
