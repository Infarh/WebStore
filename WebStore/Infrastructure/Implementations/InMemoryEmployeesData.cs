using System.Collections.Generic;
using System.Linq;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Infrastructure.Implementations
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        private static readonly List<EmployeeView> __Employees = new List<EmployeeView>
        {
            new EmployeeView { Id = 1, FirstName = "Иван", LastName = "Иванов", Patronymic = "Иванович", Age = 23 },
            new EmployeeView { Id = 2, FirstName = "Пётр", LastName = "Петров", Patronymic = "Петрович", Age = 32 },
            new EmployeeView { Id = 3, FirstName = "Сидор", LastName = "Сидоров", Patronymic = "Сидорович", Age = 33 },
        };

        public IEnumerable<EmployeeView> Get() => __Employees;

        public EmployeeView Get(int id) => __Employees.FirstOrDefault(employee => employee.Id == id);

        public void SaveChanges() { }

        public void AddNew(EmployeeView Employee)
        {
            Employee.Id = __Employees.Count == 0 ? 1 : __Employees.Max(employee => employee.Id) + 1;
            __Employees.Add(Employee);
        }

        public void Delete(int id) => __Employees.RemoveAll(employee => employee.Id == id);
    }
}
