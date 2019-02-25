using System.Collections.Generic;
using WebStore.Models;

namespace WebStore.Infrastructure.Interfaces
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
