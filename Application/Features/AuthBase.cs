using AutoMapper;
using Domain.Contracts.Identity;

namespace Application.Features;

public class AuthBase
{
    public IIdentityService IdentityService { get; }
    public IMapper Mapper { get; }

    public AuthBase(IIdentityService identityService,IMapper mapper)
    {
        IdentityService = identityService;
        Mapper = mapper;
    }
}