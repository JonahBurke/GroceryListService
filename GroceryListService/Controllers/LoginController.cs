using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using javax.jws;
using Microsoft.AspNetCore.Mvc;

namespace GroceryListService.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [WebMethod]
        public static string ProcessIT(string name, string address)
        {
            string result = "Welcome Mr. " + name + ". Your address is '" + address + "'.";
            return result;
        }
    }
}
