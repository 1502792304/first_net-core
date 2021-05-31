using DTO.Interface;
using first_net__core.Filter;
using first_net__core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace first_net__core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMath _iMath;
        public HomeController(ILogger<HomeController> logger, IMath iMath)
        {
            _logger = logger;
            _iMath = iMath; 
        }

        public IActionResult Index(int? id)
        {
            Response.ContentType = "text/html;charset=UTF-8";
            
            HttpContext.Session.SetString("userinfo","aa");
            String str = HttpContext.Session.GetString("userinfo");
            //int re=_iMath.sum(1, 2);
            int testRecode = 12;
            IMath imath_1= (IMath)HttpContext.RequestServices.GetService(typeof(IMath));
            int re1= imath_1.sum(10,20);

            

            return View();
        }

        [ServiceFilter(typeof(actionFilter))]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
