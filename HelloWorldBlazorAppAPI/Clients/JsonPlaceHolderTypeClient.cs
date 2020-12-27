using HelloWorldBlazorAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HelloWorldBlazorAppAPI.Clients
{
    public class JsonPlaceHolderTypeClient
    {
        private HttpClient _httpClient;
        public JsonPlaceHolderTypeClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Todos>> GetTodos()
        {
            return await _httpClient.GetFromJsonAsync<List<Todos>>("/todos");
        }
    }
}
