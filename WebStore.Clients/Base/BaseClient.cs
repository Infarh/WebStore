using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

namespace WebStore.Clients.Base
{
    /// <summary>Базовый класс клиента</summary>
    public abstract class BaseClient
    {
        /// <summary>HTTP-клиент для организации связи</summary>
        protected HttpClient _Client;

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
    }
}
