using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerHost.Quickstart.UI
{
    [SecurityHeaders]
    public class RegisterController : Controller
    {


        public RegisterController()
        {

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
