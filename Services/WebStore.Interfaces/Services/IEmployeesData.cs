using System.Collections.Generic;
using WebStore.Entities.ViewModels;

namespace WebStore.Interfaces.Services
{
    public interface IEmployeesData
    {
        IEnumerable<EmployeeView> Get();
        EmployeeView Get(int id);
        void SaveChanges();
        void AddNew(EmployeeView Employee);
        void Delete(int id);
    }
}
