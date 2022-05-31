using LimitLessLegal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.IO;

namespace LimitLessLegal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _context;
        public HomeController(ILogger<HomeController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult admin()
        {
            return View();
        }
        public ActionResult login(Users users)
        {
            var dbusers = _context.Userss.Where(c => c.username == users.username && c.userpassword == users.userpassword).ToList();
            if (users.username == null && users.userpassword == null)
            {
                ViewBag.error = "";
                return View();
            }
            else if (dbusers.Count == 0)
            {

                ViewBag.error = "عفوا خطأ في اسم المستخدم او كلمة المرور";
                return View();
            }
            else
            {
                //session for roles
                string permission_id = dbusers[0].permission_id.ToString();
                string username = dbusers[0].username.ToString();
                int userid =int.Parse( dbusers[0].userId.ToString());
                HttpContext.Session.SetString("permission_id", permission_id);
                HttpContext.Session.SetString("username", username);
                HttpContext.Session.SetString("userid", userid.ToString());
                return RedirectToAction("admin", "home");
            }

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult noacces()
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
