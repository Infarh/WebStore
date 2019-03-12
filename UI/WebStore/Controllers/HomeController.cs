using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Interfaces.Api;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IValuesService _Values;

        public HomeController(IValuesService values) => _Values = values;

        public IActionResult Index() => View();

        public IActionResult ContactUs() => View();
        public IActionResult BlogSingle() => View();
        public IActionResult Blog() => View();
        public IActionResult NotFoundPage()
        {
            //HttpContext.Response.StatusCode = 404;
            return View();
        }

        public IActionResult ErrorStatus(string id)
        {
            switch (id)
            {
                case "404":
                    return RedirectToAction(nameof(NotFoundPage));
                default:
                    return Content($"Статусный код ошибки {id}");
            }
        }

        public async Task<IActionResult> WebApiTest()
        {
            var values = await _Values.GetAsync();
            return View(values);
        }
    }
}