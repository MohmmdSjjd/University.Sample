using Application.Features.Commands.Student.Create;
using Application.Features.Commands.Student.Delete;
using Application.Features.Commands.Student.Update;
using Application.Features.Queries.Student.GetByNationalCode;
using Application.Features.Queries.Student.GetByStudentCode;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class StudentController : ControllerBase
    {

        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("nationalCode")]
        public async Task<IActionResult> GetStudent([FromQuery] GetStudentByNationalCodeQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("StudentCode")]
        public async Task<IActionResult> GetStudent([FromQuery] GetStudentByStudentCodeQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent([FromBody] DeleteStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
