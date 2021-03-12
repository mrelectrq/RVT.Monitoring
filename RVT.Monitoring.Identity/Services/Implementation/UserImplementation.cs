using RVT.Monitoring.Identity.Data.IdentityModel;
using RVT.Monitoring.Identity.Services.Interfaces;
using RVT.Monitoring.Identity.Services.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RVT.Monitoring.Identity.Services.Implementation
{
    public class UserImplementation : IUserService
    {

        private readonly UserDbContext _dbContext;
        public UserImplementation(UserDbContext userDbContext)
        {
            _dbContext = userDbContext;
        }
        public AuthenticationResponse Authenticate(AuthenticationMessage message)
        {
            throw new NotImplementedException();
        }

        public RegistrationResponse Register(RegistrationMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
