using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _Employees;

        public EmployeesController(IEmployeesData EmployeesData) => _Employees = EmployeesData;

        public IActionResult Index() => View(_Employees.Get());

        public IActionResult Details(int? id)
        {
            if (id is null) return NotFound();
            var employee = _Employees.Get((int)id);
            if (employee is null) return NotFound();
            return View(employee);
        }

        public IActionResult Edit(int? id)
        {
            if (id is null) return View(new EmployeeView());
            var employee = _Employees.Get((int)id);
            if (employee is null) return NotFound();
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeView EmployeInfo)
        {
            if (!ModelState.IsValid) return View(EmployeInfo);
            if (EmployeInfo.Id == 0)
                _Employees.AddNew(EmployeInfo);
            else
            {
                var employee = _Employees.Get(EmployeInfo.Id);
                if (employee is null) return NotFound();
                employee.FirstName = EmployeInfo.FirstName;
                employee.LastName = EmployeInfo.LastName;
                employee.Patronymic = EmployeInfo.Patronymic;
                employee.Age = EmployeInfo.Age;
            }
            _Employees.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            if (_Employees.Get(id) is null) return NotFound();
            _Employees.Delete(id);
            _Employees.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}