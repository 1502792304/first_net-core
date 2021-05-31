using first_net__core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace first_net__core.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
       
        public IActionResult login()
        {
            return View();
        }

        public IActionResult index() => View();

        [HttpPost]
        public IActionResult Go_Login()
        {
            HttpContext.Response.Cookies.Append("user","yes");
            return new RedirectToActionResult("index", "home",null);
        }

    }
}
