using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin")]

    public class HomeController : Controller
    {
        private readonly IProductData _ProductData;

        public HomeController(IProductData ProductData) => _ProductData = ProductData;

        public IActionResult Index() => View();

        public IActionResult ProductList() => View(_ProductData.GetProducts(null));

        public IActionResult Details(int Id)
        {
            throw new NotImplementedException();
        }

        public IActionResult Create()
        {
            throw new NotImplementedException();
        }

        public IActionResult Edit(int Id)
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}