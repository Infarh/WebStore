using System;
using System.Collections.Generic;
using System.Linq;
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
            return Content(DateTime.Now.ToString("R"));
        }
    }
}