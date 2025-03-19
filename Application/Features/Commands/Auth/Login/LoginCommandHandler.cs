using System.Net;
using Domain.Contracts.Identity;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Commands.Auth.Login;

public class LoginCommandHandler : AuthBase, IRequestHandler<LoginCommand, string>
{
    public LoginCommandHandler(IIdentityService identityService) : base(identityService)
    {
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var login = await IdentityService.LoginAsync(request.Email, request.Password);

        if(login == null)
        {
            throw new ApiException("Invalid login attempt.",(int)HttpStatusCode.NotAcceptable);
        }

        return login;
    }

}