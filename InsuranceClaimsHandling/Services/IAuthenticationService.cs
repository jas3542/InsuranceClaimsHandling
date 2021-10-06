using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaimsHandling
{
    public interface IAuthenticationService
    {
        string Authentication(string name, string password);
    }
}
