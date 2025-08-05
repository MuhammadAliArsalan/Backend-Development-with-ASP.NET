using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller 
    {
        public static List<Customer> customers = new List<Customer>()
        {
            new Customer(){
                Id=101,Name="Ali",Amount=12000
            },
            new Customer()
            {
                Id=102,Name="Hasan",Amount=13000,
            },
            new Customer()
            {
                Id=103,Name="Khan",Amount=12000
            }
        };
        public IActionResult Index()
        {
            ViewBag.Message = "Customer Management System";
            ViewBag.CustomerCount = customers.Count();

            return View(customers);
        }
        public IActionResult Details()
        {
            return View();
        }
        [Route("/sample/message")]

        public IActionResult Message()
        {
            var courseNames = new List<string> { "C# for .NET devs", "Backend dev with ASP.NET" };
            ViewData["Courses"]=courseNames;            
            ViewBag.MyMessage = "This is Message Page of Customer page";

            return View();
        }
        private static List<string> cartItems = new List<string>();

        [HttpPost]
        public IActionResult AddTocart(string itemName)
        {
            if (!string.IsNullOrEmpty(itemName))
            {
                cartItems.Add(itemName); // Save item
                TempData["LastItem"] = itemName; // Pass item name to next view
            }

            return RedirectToAction("Thanks");
        }
        [HttpGet]
        public IActionResult AddTocart()
        {
            return View();
        }

        public IActionResult Thanks()
        {
            ViewBag.PurchasedItem = TempData["LastItem"];
            return View();
        }

    }
}
