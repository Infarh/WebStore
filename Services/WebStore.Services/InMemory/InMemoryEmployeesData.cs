using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Entities.ViewModels;
using WebStore.Interfaces.Services;

namespace WebStore.Services.InMemory
{
    /// <summary>Реализация сервиса уравления сотрудниками в памяти</summary>
    public class InMemoryEmployeesData : IEmployeesData
    {
        /// <summary>Хранилище сотрудников</summary>
        private static readonly List<EmployeeView> __Employees = new List<EmployeeView>
        {
            new EmployeeView { Id = 1, FirstName = "Иван", LastName = "Иванов", Patronymic = "Иванович", Age = 23 },
            new EmployeeView { Id = 2, FirstName = "Пётр", LastName = "Петров", Patronymic = "Петрович", Age = 32 },
            new EmployeeView { Id = 3, FirstName = "Сидор", LastName = "Сидоров", Patronymic = "Сидорович", Age = 33 },
        };

        public IEnumerable<EmployeeView> GetAll() => __Employees;

        public EmployeeView GetById(int id) => __Employees.FirstOrDefault(employee => employee.Id == id);

        public EmployeeView Update(int id, EmployeeView Employee)
        {
            if (Employee is null) throw new ArgumentNullException(nameof(Employee));

            var employee = GetById(id);
            if(employee is null) throw new InvalidOperationException("Сотрудник с указанным идентификатором не обнаружен");

            employee.FirstName = Employee.FirstName;
            employee.LastName = Employee.LastName;
            employee.Patronymic = Employee.Patronymic;
            employee.Position = Employee.Position;
            employee.Age = Employee.Age;

            return employee;
        }

        public void AddNew(EmployeeView Employee)
        {
            if(__Employees.Contains(Employee)) return;
            Employee.Id = __Employees.Count == 0 ? 1 : __Employees.Max(employee => employee.Id) + 1;
            __Employees.Add(Employee);
        }

        public void Delete(int id) => __Employees.RemoveAll(employee => employee.Id == id);

        public void SaveChanges() { }
    }
}
