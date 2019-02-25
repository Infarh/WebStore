using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebStore.Clients.Base;
using WebStore.Interfaces.Api;

namespace WebStore.Clients.Services
{
    public class ValuesClient : BaseClient, IValuesServices
    {
        protected override string ServiceAddress { get; set; }

        public ValuesClient(IConfiguration configuration) 
            : base(configuration)
        {
            ServiceAddress = "api/values";
        }

        public IEnumerable<string> Get() => GetAsync().Result;

        public async Task<IEnumerable<string>> GetAsync()
        {
            var response = await _Client.GetAsync(ServiceAddress);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadAsAsync<List<string>>()
                : Enumerable.Empty<string>();
        }

        public string Get(int id) => GetAsync(id).Result;

        public async Task<string> GetAsync(int id)
        {
            var response = await _Client.GetAsync($"{ServiceAddress}/get/{id}");
            return response.IsSuccessStatusCode
                ? await response.Content.ReadAsAsync<string>()
                : string.Empty;
        }

        public Uri Post(string value) => PostAsync(value).Result;

        public async Task<Uri> PostAsync(string value) => 
            (await _Client.PostAsJsonAsync($"{ServiceAddress}/post", value))
            .EnsureSuccessStatusCode()
            .Headers
            .Location;

        public HttpStatusCode Put(int id, string value) => PutAsync(id, value).Result;

        public async Task<HttpStatusCode> PutAsync(int id, string value) =>
            (await _Client.PutAsJsonAsync($"{ServiceAddress}/put/{id}", value))
            .EnsureSuccessStatusCode()
            .StatusCode;

        public HttpStatusCode Delete(int id) => DeleteAsync(id).Result;

        public async Task<HttpStatusCode> DeleteAsync(int id) => 
            (await _Client.DeleteAsync($"{ServiceAddress}/delete/{id}"))
            //.EnsureSuccessStatusCode()
            .StatusCode;
    }
}
