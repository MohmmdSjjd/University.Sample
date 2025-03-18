using Application.Features.Commands.Student.Create;
using Application.Features.Commands.Student.Delete;
using Application.Features.Commands.Student.Update;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
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
