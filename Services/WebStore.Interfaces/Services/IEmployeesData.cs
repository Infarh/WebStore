using System.Collections.Generic;
using WebStore.Entities.ViewModels;

namespace WebStore.Interfaces.Services
{
    /// <summary>Сервис управления сотрудниками</summary>
    public interface IEmployeesData
    {
        /// <summary>Получить всех сотрудников</summary>
        /// <returns></returns>
        IEnumerable<EmployeeView> Get();

        /// <summary>Получить сотрудника по идентификатору</summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <returns>Сотрудник с указанным идентификатором</returns>
        EmployeeView Get(int id);

        /// <summary>Добавить нового сотрудника</summary>
        /// <param name="Employee">Добавляемый сотрудник</param>
        void AddNew(EmployeeView Employee);

        /// <summary>Удалить сотрудника по его идентификатору</summary>
        /// <param name="id">Идентификатор удаляемого сотрудника</param>
        void Delete(int id);

        /// <summary>Сохранить изменения</summary>
        void SaveChanges();
    }
}
