using System.Net;
using Domain.Contracts.Identity;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Commands.Auth.Register;

public class RegisterCommandHandler : AuthBase, IRequestHandler<RegisterCommand, string>
{
    public RegisterCommandHandler(IIdentityService identityService) : base(identityService)
    {
    }

    public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var register = await IdentityService.RegisterAsync(request.Email, request.Password, request.FirstName, request.LastName);

        if (register is null)
        {
            throw new ApiException("Failed to register user", (int)HttpStatusCode.BadRequest);
        }

        return register;
    }
}