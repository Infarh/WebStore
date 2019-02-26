using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebStore.Clients.Base
{
    /// <summary>Базовый класс клиента</summary>
    public abstract class BaseClient
    {
        /// <summary>HTTP-клиент для организации связи</summary>
        protected readonly HttpClient _Client;

        /// <summary>Адрес сервиса</summary>
        protected abstract string ServiceAddress { get; set; }

        /// <summary>Инициализация базового клианте</summary>
        /// <param name="configuration">Конфигурация приложения</param>
        protected BaseClient(IConfiguration configuration)
        {
            _Client = new HttpClient { BaseAddress = new Uri(configuration["ClientAddress"]) };
            _Client.DefaultRequestHeaders.Accept.Clear();
            _Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #region virtual GET-POST-PUT-DELETE/Async

        protected virtual T Get<T>(string uri) where T : new() => GetAsync<T>(uri).Result;
        protected virtual async Task<T> GetAsync<T>(string uri) where T : new()
        {
            var response = await _Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<T>();
            return new T();
        }

        protected virtual HttpResponseMessage Post<T>(string uri, T item) => PostAsync(uri, item).Result;
        protected virtual async Task<HttpResponseMessage> PostAsync<T>(string uri, T item) =>
            (await _Client.PostAsJsonAsync(uri, item)).EnsureSuccessStatusCode();

        protected virtual HttpResponseMessage Put<T>(string uri, T item) => PutAsync(uri, item).Result;
        protected virtual async Task<HttpResponseMessage> PutAsync<T>(string uri, T item) =>
            (await _Client.PutAsJsonAsync(uri, item)).EnsureSuccessStatusCode();

        protected virtual HttpResponseMessage Delete(string uri) => DeleteAsync(uri).Result;
        protected virtual Task<HttpResponseMessage> DeleteAsync(string uri) => _Client.DeleteAsync(uri); 

        #endregion
    }
}
