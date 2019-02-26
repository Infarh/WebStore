using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using WebStore.Clients.Base;
using WebStore.Entities.ViewModels;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Services.Employees
{
    public class EmployeesClient : BaseClient, IEmployeesData
    {
        public EmployeesClient(IConfiguration configuration) : base(configuration) => ServiceAddress = "api/employees";

        public IEnumerable<EmployeeView> GetAll() => Get<List<EmployeeView>>(ServiceAddress);

        public EmployeeView GetById(int id) => Get<EmployeeView>($"{ServiceAddress}/{id}");

        public EmployeeView Update(int id, EmployeeView Employee) =>
            Put($"{ServiceAddress}/{id}", Employee)
                .Content
                .ReadAsAsync<EmployeeView>()
                .Result;

        public void AddNew(EmployeeView Employee) => Post(ServiceAddress, Employee);

        public void Delete(int id) => Delete($"{ServiceAddress}/{id}");

        public void SaveChanges() { }
    }
}
