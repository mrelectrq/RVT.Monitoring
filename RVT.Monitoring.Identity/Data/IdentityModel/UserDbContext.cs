using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static RVT.Monitoring.Identity.Data.IdentityModel.UserDbContext;

namespace RVT.Monitoring.Identity.Data.IdentityModel
{
    public class UserDbContext : IdentityDbContext<RVTUser, RVTRole, Guid,RVTUserClaims,RVTUserRoles,
        RVTUserLogins,RVTRoleClaims,RVTUserTokens>
    {


        public UserDbContext(DbContextOptions<UserDbContext> opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RVTUser>().ToTable("Users");
            modelBuilder.Entity<RVTRoleClaims>().ToTable("RVTRoleClaims");
            modelBuilder.Entity<RVTUserClaims>().ToTable("RVTUserClaims");
            modelBuilder.Entity<RVTUserLogins>().ToTable("RVTUserLogins");
            modelBuilder.Entity<RVTUserRoles>().ToTable("RVTUserRoles");
            modelBuilder.Entity<RVTUserTokens>().ToTable("RVTUserTokens");
            modelBuilder.Entity<RVTRole>().ToTable("RVTRoles");
        }


        public class RVTRoleClaims : IdentityRoleClaim<Guid> { }

        public class RVTUserClaims : IdentityUserClaim<Guid> { }
        public class RVTUserLogins : IdentityUserLogin<Guid> { }
        public class RVTUserRoles : IdentityUserRole<Guid> { }
        public class RVTUserTokens : IdentityUserToken<Guid> { }




    }
}
