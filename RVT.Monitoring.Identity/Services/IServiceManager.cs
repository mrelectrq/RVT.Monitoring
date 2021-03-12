using RVT.Monitoring.Identity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RVT.Monitoring.Identity.Services
{
    public interface IServiceManager
    {
        IUserService GetUserServices();
    }
}
