using AutoMapper;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Events;
using IdentityServer4.Services;
using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RVT.Monitoring.Identity.Data.IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServerHost.Quickstart.UI
{
    [SecurityHeaders]
    public class RegisterController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserDbContext _dbContext;
        private readonly UserManager<RVTUser> _userManager;
        private readonly SignInManager<RVTUser> _signInManager;

        public RegisterController(IMapper mapper ,UserManager<RVTUser> manager,SignInManager<RVTUser> _signManager)
        
        {
            _mapper = mapper;
            _userManager = manager;
            _signInManager = _signManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                
                return View();
            }
            
            if(_userManager.FindByEmailAsync(model.Email).Result!= null 
                || _userManager.FindByNameAsync(model.Username).Result != null)
            {
                ModelState.AddModelError(string.Empty, "Username or password arleady in use");
                return View();
            }        
                                  
            var rVTUser = new RVTUser()
            {
                UserName = model.Username,
                PasswordHash = model.Password.ToSha256(),
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                RegisterTimeStamp = DateTime.Now,
                EmailConfirmed = true,      // for the moment
                PhoneNumberConfirmed = true, // for the moment
                
            };

            var result = _userManager.CreateAsync(rVTUser, model.Password.ToSha256()).Result;
            var user = _signInManager.UserManager.FindByEmailAsync(rVTUser.Email).Result;
            await _userManager.AddClaimAsync(user, new Claim(JwtClaimTypes.FamilyName, model.LastName));
            await _userManager.AddClaimAsync(user, new Claim(JwtClaimTypes.Name, model.FirstName));
         
            await _userManager.AddToRoleAsync(user, "User");

            
            return RedirectToAction("Login", "Account");
        }

        [AllowAnonymous]
        [AcceptVerbs("GET","POST")]
        public IActionResult CheckEmail(string email)
        {
            if(_userManager.FindByEmailAsync(email).Result!=null)
            {
                return Json($"Email {email} is arleady in use");
            }
            return Json(true);
        }
    }
}
