using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult GetAccount()
    {
        return View(); // Shows the registration form
    }

    [HttpPost]
    public IActionResult PostAccount(Account account)  //the parameters should match the class name defined in your model file, not the file name itself.
    {
        if (ModelState.IsValid)
        {
            // All validations passed
            return View("Success"); // Go to success page
        }

        // Validation failed, return the same form with error messages
        return View("GetAccount");
    }
}
