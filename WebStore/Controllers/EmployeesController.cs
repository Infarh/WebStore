using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
        private static readonly List<EmployeeView> __Employees = new List<EmployeeView>
        {
            new EmployeeView { Id = 1, FirstName = "Иван", LastName = "Иванов", Patronymic = "Иванович", Age = 23 },
            new EmployeeView { Id = 2, FirstName = "Пётр", LastName = "Петров", Patronymic = "Петрович", Age = 32 },
            new EmployeeView { Id = 3, FirstName = "Сидор", LastName = "Сидоров", Patronymic = "Сидорович", Age = 33 },
        };

        public IActionResult Index() => View(__Employees);

        public IActionResult Details(int? id)
        {
            if (id is null) return NotFound();
            var employee = __Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null) return NotFound();
            return View(employee);
        }

        public IActionResult Edit(int? id)
        {
            if (id is null) return NotFound();
            var employee = __Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null) return NotFound();
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeView EmployeInfo)
        {
            if (!ModelState.IsValid) return View(EmployeInfo);
            var employee = __Employees.FirstOrDefault(e => e.Id == EmployeInfo.Id);
            if (employee is null) return NotFound();
            employee.FirstName = EmployeInfo.FirstName;
            employee.LastName = EmployeInfo.LastName;
            employee.Patronymic = EmployeInfo.Patronymic;
            employee.Age = EmployeInfo.Age;
            return RedirectToAction(nameof(Details), new { id = EmployeInfo.Id });
        }
    }
}