using MediatR;

namespace Application.Features.Commands.Auth.Login
{
    public record LoginCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
