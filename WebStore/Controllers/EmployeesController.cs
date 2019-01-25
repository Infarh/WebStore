﻿using System;
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
            if (id is null) return NotFound();
            var employee = _Employees.Get((int)id);
            if (employee is null) return NotFound();
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeView EmployeInfo)
        {
            if (!ModelState.IsValid) return View(EmployeInfo);
            var employee = _Employees.Get(EmployeInfo.Id);
            if (employee is null) return NotFound();
            employee.FirstName = EmployeInfo.FirstName;
            employee.LastName = EmployeInfo.LastName;
            employee.Patronymic = EmployeInfo.Patronymic;
            employee.Age = EmployeInfo.Age;
            return RedirectToAction(nameof(Details), new { id = EmployeInfo.Id });
        }
    }
}