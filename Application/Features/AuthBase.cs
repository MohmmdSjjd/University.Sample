using Domain.Contracts.Identity;

namespace Application.Features;

public class AuthBase
{
    public IIdentityService IdentityService { get; }

    public AuthBase(IIdentityService identityService)
    {
        IdentityService = identityService;
    }
}