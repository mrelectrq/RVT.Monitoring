using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RVT.Monitoring.Identity.Data.IdentityModel
{
    public class UserDbContext : IdentityDbContext<RVTUser, RVTRole, Guid>
    {

        public UserDbContext(DbContextOptions<UserDbContext> opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
