using Microsoft.EntityFrameworkCore;
using RVT.Monitoring.Identity.Data.IdentityModel;
using RVT.Monitoring.Identity.Services.Implementation;
using RVT.Monitoring.Identity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RVT.Monitoring.Identity.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly UserDbContext _context;
        public ServiceManager(UserDbContext dbContext)
        {
            _context = dbContext;
        }

        public IUserService GetUserServices()
        {
            return new UserImplementation(_context);
        }


    }
}
