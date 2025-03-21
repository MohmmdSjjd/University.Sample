using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos.Student.Commands;
using MediatR;

namespace Application.Features.Commands.Student.Delete
{
    public record DeleteStudentCommand : IRequest<DeleteStudentCommandResponseDto>
    {
        public Guid Id { get; set; }
    }
}
