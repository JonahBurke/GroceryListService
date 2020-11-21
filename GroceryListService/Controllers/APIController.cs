using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace GroceryListService.Controllers
{
    public class APIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public string InsertTODatabase(string ProductName, string Price, string UserID, string ListName)
        {

            return HttpUtility.HtmlEncode("Product Name is " + ProductName + ", Price is " + Price + " User ID is " + UserID + " List name is " + ListName);
        }
    }
}
