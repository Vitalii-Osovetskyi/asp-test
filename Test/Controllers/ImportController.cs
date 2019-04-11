using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVC.Helper;

namespace MVC.Controllers
{
    public class ImportController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ImportController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Import()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Import(IFormFile xmlOrder)
        {
            AllOrder LastOrders;
            string path;
            var originalImageFile = ContentDispositionHeaderValue.Parse(xmlOrder.ContentDisposition).FileName.Trim();
            var filePath = Path.GetTempFileName();
            string webRootPath = _hostingEnvironment.WebRootPath;
            using (FileStream fs = System.IO.File.Create(Path.Combine(webRootPath, originalImageFile.Value)))
            {
                path = fs.Name;
                xmlOrder.CopyTo(fs);
                fs.Flush();
            }
            XmlSerializer serializer = new XmlSerializer(typeof(AllOrder));
            using (StreamReader reader = new StreamReader(path))
            {
                LastOrders = (AllOrder)serializer.Deserialize(reader);
            }
            List<OrderDB> addedOrders = await Task.Run(() => new DBHelper().AddOrders(LastOrders.Orders));
            System.IO.File.Delete(path);
            return View(addedOrders);
        }

        [HttpPost]
        public async Task<IActionResult> SetupOrders(List<OrderDB> orders)
        {
            await Task.Run(() => new DBHelper().SetupOrders(orders));
            TempData["msg"] = "<script>alert('Orders added!');</script>";
            return RedirectToAction("Import");
        }
    }
}
