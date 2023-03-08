using Newtonsoft.Json;
using SWAPI.Models;
using System.Net.Http.Headers;

namespace SWAPI.Services
{
    public class StarWarsMovie : IStarWarsMovie
    {
        const string SWAPIBaseUrl = "http://swapi.dev/api/people/?page";
        private readonly IHttpClientFactory _httpClientFactory;
        public StarWarsMovie(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseSW> GetPublicStarWarsMovie(int PageNumber)
        {
            var client = _httpClientFactory.CreateClient(SWAPIBaseUrl + "=" + PageNumber);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(SWAPIBaseUrl + "=" + PageNumber).Result;
            return await Task.Run(() => JsonConvert.DeserializeObject<ResponseSW>(response.Content.ReadAsStringAsync().Result.ToString()));
        }

        public async Task<ResponseDownload> GetProtectedStarWarsMovie(int PageNumber)
        {
            var client = _httpClientFactory.CreateClient(SWAPIBaseUrl + "=" + PageNumber);
            client.BaseAddress = new Uri(SWAPIBaseUrl + "=" + PageNumber);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(SWAPIBaseUrl + "=" + PageNumber).Result;
            return await Task.Run(() => JsonConvert.DeserializeObject<ResponseDownload>(response.Content.ReadAsStringAsync().Result.ToString()));
        }

    }
}