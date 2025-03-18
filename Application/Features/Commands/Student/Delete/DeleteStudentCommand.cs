using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Commands.Student.Delete
{
    public record DeleteStudentCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
