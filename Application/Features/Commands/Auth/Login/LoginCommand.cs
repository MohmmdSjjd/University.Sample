using Application.Dtos.Auth.Commands;
using MediatR;

namespace Application.Features.Commands.Auth.Login
{
    public record LoginCommand : IRequest<LoginCommandResponseDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
