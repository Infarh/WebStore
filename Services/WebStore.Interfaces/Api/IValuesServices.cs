using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace WebStore.Interfaces.Api
{
    public interface IValuesServices
    {
        /// <summary>Получить все элементы данных</summary>
        /// <returns>Перечисление строковых данных</returns>
        IEnumerable<string> Get();

        /// <summary>Асинхронно получить все элементы данных</summary>
        /// <returns>Задача извлечения перечисления элементов данных</returns>
        Task<IEnumerable<string>> GetAsync();

        /// <summary>Получить значение по заданному идентификатору</summary>
        /// <param name="id">Идентификатор значения элемента данных</param>
        /// <returns>Элемент данных с заданным значением идентификатора</returns>
        string Get(int id);

        /// <summary>Асинхронно получить значение по заданному идентификатору</summary>
        /// <param name="id">Идентификатор значения элемента данных</param>
        /// <returns>Задача асинхронного получения элемента данных с заданным значением идентификатора</returns>
        Task<string> GetAsync(int id);

        /// <summary>Добавление нового элемента данных</summary>
        /// <param name="value">Добавляемый элемент данных</param>
        /// <returns>Адрес созданного элемента данных</returns>
        Uri Post(string value);

        /// <summary>Асинхронное добавление нового элемента данных</summary>
        /// <param name="value">Добавляемый элемент данных</param>
        /// <returns>Задача добавления нового элемента данных</returns>
        Task<Uri> PostAsync(string value);

        /// <summary>Обновление элемента данных</summary>
        /// <param name="id">Идентификатор обновляемого элемента данных</param>
        /// <param name="value">Новое значение</param>
        /// <returns>Результа выполения операции обновления</returns>
        HttpStatusCode Put(int id, string value);

        /// <summary>Асинхронное обновление элемента данных</summary>
        /// <param name="id">Идентификатор обновляемого элемента данных</param>
        /// <param name="value">Новое значение элемента данных</param>
        /// <returns>Результат обновления</returns>
        Task<HttpStatusCode> PutAsync(int id, string value);

        /// <summary>Удаление элемента данных</summary>
        /// <param name="id">Идентификатор удаляемого элемента</param>
        /// <returns>Результат выполения операции удаления</returns>
        HttpStatusCode Delete(int id);

        /// <summary>Асинхронное удаление элемента данных</summary>
        /// <param name="id">Идентификатор удаляемого элемента</param>
        /// <returns>Результат выполения операции удаления</returns>
        Task<HttpStatusCode> DeleteAsync(int id);
    }
}
