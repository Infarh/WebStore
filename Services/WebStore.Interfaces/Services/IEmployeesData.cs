using System.Collections.Generic;
using WebStore.Entities.ViewModels;

namespace WebStore.Interfaces.Services
{
    /// <summary>Сервис управления сотрудниками</summary>
    public interface IEmployeesData
    {
        /// <summary>Получить всех сотрудников</summary>
        /// <returns></returns>
        IEnumerable<EmployeeView> GetAll();

        /// <summary>Получить сотрудника по идентификатору</summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <returns>Сотрудник с указанным идентификатором</returns>
        EmployeeView GetById(int id);

        /// <summary>Обновление сотрудника</summary>
        /// <param name="id">Идентификатор обновляемого сотрудника</param>
        /// <param name="Employee">Новые данные сотрудника</param>
        /// <returns>Обновлённые данные сотрудника</returns>
        EmployeeView Update(int id, EmployeeView Employee);

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
