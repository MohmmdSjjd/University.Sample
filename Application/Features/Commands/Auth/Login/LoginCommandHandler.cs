using System.Net;
using Application.Dtos.Auth.Commands;
using AutoMapper;
using Domain.Contracts.Identity;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Commands.Auth.Login;

public class LoginCommandHandler : AuthBase, IRequestHandler<LoginCommand, LoginCommandResponseDto>
{
    public LoginCommandHandler(IIdentityService identityService,IMapper mapper) : base(identityService,mapper)
    {
    }

    public async Task<LoginCommandResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var login = await IdentityService.LoginAsync(request.Email, request.Password);

        if(login == null)
        {
            throw new ApiException("Invalid login attempt.",(int)HttpStatusCode.NotAcceptable);
        }

        return Mapper.Map<LoginCommandResponseDto>(login);
    }

}