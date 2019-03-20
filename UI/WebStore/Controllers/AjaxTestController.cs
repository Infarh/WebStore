using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class AjaxTestController : Controller
    {
        //https://www.learnrazorpages.com/razor-pages/ajax/unobtrusive-ajax
        public IActionResult Index() => View();

        public async Task<IActionResult> GetTestData()
        {
            await Task.Delay(3000);
            return PartialView("Partial/_DataView", DateTime.Now);
        }

        public async Task<IActionResult> GetDataJSON(int? id, string msg)
        {
            await Task.Delay(3000);
            return Json(new TestDataItem { Message = $"Test message ({id ?? 0}):{msg}", Time = DateTime.Now });
        }

        private class TestDataItem
        {
            public string Message { get; set; }
            public DateTime Time { get; set; }
        }
    }
}