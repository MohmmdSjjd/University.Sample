using System.Net;
using Application.Dtos.Auth.Commands;
using AutoMapper;
using Domain.Contracts.Identity;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Commands.Auth.Register;

public class RegisterCommandHandler : AuthBase, IRequestHandler<RegisterCommand, RegisterCommandResponseDto>
{
    public RegisterCommandHandler(IIdentityService identityService,IMapper mapper) : base(identityService,mapper)
    {
    }

    public async Task<RegisterCommandResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var register = await IdentityService.RegisterAsync(request.Email, request.Password, request.FirstName, request.LastName);

        return Mapper.Map<RegisterCommandResponseDto>(register);
    }
}