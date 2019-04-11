using Microsoft.AspNetCore.Mvc;
using MVC.Helper;

namespace MVC.Controllers
{
    public class OrderDetailController : Controller
    {
        [Route("OrderDetail/OrderDetail/{id}")]
        public IActionResult OrderDetail(int id)
        {
            return View(new DBHelper().GetArticlesByOrderId(id));
        }
    }
}
