using RVT.Monitoring.Identity.Services.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RVT.Monitoring.Identity.Services.Interfaces
{
    public interface IUserService
    {
        public RegistrationResponse Register(RegistrationMessage message);

        public AuthenticationResponse Authenticate(AuthenticationMessage message);

    }
}
