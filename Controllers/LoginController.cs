using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            HttpContext.Session.SetString("userName", "Ali");
            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            string? username = HttpContext.Session.GetString("userName");

            if (username == null)
            {
                return RedirectToAction("Login");
            }
            ViewBag.Username = username;
            return View();
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("userName");
            return RedirectToAction("Login");
        }

        public IActionResult QueryTest()
        {
            string name = "Ali";

            if (!string.IsNullOrEmpty(HttpContext.Request.Query["name"]))
            {
                name = HttpContext.Request.Query["name"];
            }

            ViewBag.Name = name;
            return View();
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Register(string username, string password, string address)
        {
            ViewBag.Username2 = username;
            ViewBag.Password = password;
            ViewBag.Address = address;
            return RedirectToAction("Welcome");
        }
        public IActionResult Welcome()
        {
            return View();
        }


    }
}