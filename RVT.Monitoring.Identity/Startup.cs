using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RVT.Monitoring.Identity.Data;
using RVT.Monitoring.Identity.Data.IdentityModel;
using AutoMapper;


namespace RVT.Monitoring.Identity
{
    public class Startup
    {  
        public void ConfigureServices(IServiceCollection services)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            

            services.AddDbContext<UserDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.IDENTITY_USERS_CONNECION);
            });

            services.AddIdentity<RVTUser, RVTRole>()
               .AddEntityFrameworkStores<UserDbContext>()
               .AddDefaultUI()
               .AddDefaultTokenProviders()
               .AddRoles<RVTRole>()
               .AddDefaultTokenProviders();
           
            services.AddMvc(opt =>
            {
                opt.EnableEndpointRouting = false;
            });


            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddConfigurationStore(opt =>
                {
                    opt.ConfigureDbContext = builder =>
                    builder.UseSqlServer(Configuration.IDENTITYDB_CONNECION,
                        sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                .AddOperationalStore(opt =>
                {
                    opt.ConfigureDbContext = builder =>
                   builder.UseSqlServer(Configuration.IDENTITYDB_CONNECION,
                       sql => sql.MigrationsAssembly(migrationsAssembly));
                    opt.EnableTokenCleanup = true;
                    opt.TokenCleanupInterval = 30;

                })
                .AddAspNetIdentity<RVTUser>();
            services.AddAutoMapper(opt =>
            {
                
            });
            services.AddAuthorization();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Account/Login";
                options.LogoutPath = $"/Account/Logout";
                options.AccessDeniedPath = $"/Account/AccessDenied";
            });


        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvcWithDefaultRoute();

        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetRequiredService<RoleManager<RVTRole>>();




                var roles = new List<RVTRole>
                {
                    new RVTRole {Name="User",NormalizedName="Lucrator",
                        Description="Sample user that can access authorized actions"},
                    new RVTRole {Name= "Moderator", NormalizedName="Lucrator nivel 2 ",
                        Description="User level 2 that can edit database arleady active actions"},
                    new RVTRole {Name= "Administrator",NormalizedName="Administrator de sistem"},
                    new RVTRole {Name= "Owner",NormalizedName="Administratia intreprinderii"}
                };


                
                foreach (var item in roles)
                {
                    var resp = context.CreateAsync(item).Result;
                }
                //context.SaveChanges();

            }
        }
    }
}
