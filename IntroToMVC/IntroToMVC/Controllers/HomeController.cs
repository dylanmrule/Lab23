using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IntroToMVC.Models;
using IntroToMVC.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using IntroToMVC.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace IntroToMVC.Controllers
{
    public class HomeController : Controller
    {
    
        private readonly ILogger<HomeController> _logger;
       
        IntroToMVCContext db = new IntroToMVCContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            var login = db.Users.Where(x => x.Username == Username).FirstOrDefault();
            if (login.Password == Password)
            {
                HttpContext.Session.SetString("Username", login.Username);
                HttpContext.Session.SetString("Money", login.Money.ToString()); ;
                ViewBag.Name = HttpContext.Session.GetString("Username");
                ViewBag.Money = HttpContext.Session.GetString("Money");
                return RedirectToAction("Index", "/Items");
            }
            else
            {
                return View();
            }
        }

            

            public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
            public IActionResult MakeNewUser(Users u)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            db.Users.Add(u);

            db.SaveChanges();
            return RedirectToAction("/Items");
          
        }
        public IActionResult Result(string Username, string Email, string Password, string Gender, string Color)
        {
            Person p = new Person();
            p.Username = Username;
            p.Email = Email;
            p.Password = Password;
            p.Gender = Gender;
            p.Color = Color;
            return View(p);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
    }
}
