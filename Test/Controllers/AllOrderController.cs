using Microsoft.AspNetCore.Mvc;
using MVC.Helper;

namespace MVC.Controllers
{
    public class AllOrderController : Controller
    {
        public IActionResult AllOrder()
        {
            return View(new DBHelper().GetAllOrder());
        }
    }
}
