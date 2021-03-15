using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RVT.Monitoring.Identity.Data.IdentityModel
{
    public class RVTUser : IdentityUser<Guid>
    {
         public string PhoneNumber { get; set; }
         public DateTime RegisterTimeStamp { get; set; }
    }
}
