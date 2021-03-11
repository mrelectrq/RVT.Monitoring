using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RVT.Monitoring.Identity.Data.IdentityModel
{
    public class RVTRole : IdentityRole<Guid>
    {
         public string Description { get; set; }
    }
}
