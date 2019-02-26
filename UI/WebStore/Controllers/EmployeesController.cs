using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Entities.ViewModels;
using WebStore.Interfaces.Services;

namespace WebStore.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _Employees;

        public EmployeesController(IEmployeesData EmployeesData) => _Employees = EmployeesData;

        public IActionResult Index() => View(_Employees.GetAll());

        public IActionResult Details(int? id)
        {
            if (id is null) return NotFound();
            var employee = _Employees.GetById((int)id);
            if (employee is null) return NotFound();
            return View(employee);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            if (id is null) return View(new EmployeeView());
            var employee = _Employees.GetById((int)id);
            if (employee is null) return NotFound();
            return View(employee);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(EmployeeView EmployeInfo)
        {
            if (!ModelState.IsValid) return View(EmployeInfo);
            if (EmployeInfo.Id == 0)
                _Employees.AddNew(EmployeInfo);
            else
            {
                var employee = _Employees.GetById(EmployeInfo.Id);
                if (employee is null) return NotFound();
                employee.FirstName = EmployeInfo.FirstName;
                employee.LastName = EmployeInfo.LastName;
                employee.Patronymic = EmployeInfo.Patronymic;
                employee.Age = EmployeInfo.Age;
                employee.Position = EmployeInfo.Position;
            }
            _Employees.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            if (_Employees.GetById(id) is null) return NotFound();
            _Employees.Delete(id);
            _Employees.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}