using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Identity
{
    public interface IIdentityService
    {
        Task<string?> RegisterAsync(string email, string password, string firstName, string lastName);
        Task<string?> LoginAsync(string email, string password);
    }
}
