using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        //session management techniques
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

        //weekly typed forms
        
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


        //Strongly typed forms
        [HttpGet]
        public IActionResult StronglyTypedRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterSuccess(RegisterViewModel register)
        {
            ViewBag.userName = register.userName;
            ViewBag.password = register.password;
            ViewBag.email = register.email;
            return View();
        }

        //Model binding

        public IActionResult UserDetail()
        {
            var user = new RegisterViewModel

            {
                userName = "Ali",
                password="123456",
                email="arsalanali873@gmail.com"
            };
            return View(user);
        }

        public IActionResult UserList()
        {
            var userList = new List<RegisterViewModel>
            {
                new RegisterViewModel { userName = "Ali", password = "123456" ,email="arslanali873@gmail.com"},
                new RegisterViewModel {userName="Ahmed",password="134890",email="ahmed873@gmail.com"},
                new RegisterViewModel {userName="Burhan",password="134890",email="burhan@gmail.com"},

            };
            return View(userList);
        }



    }
}