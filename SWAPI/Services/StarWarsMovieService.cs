using SWAPI.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SWAPI.Services
{
    public class StarWarsMovieService : IStarWarsMovieService
    {
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;
        public StarWarsMovieService(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;

        }

        public async Task<ResponseSW> GetPublicStarWarsMovie(int PageNumber)
        {
            var SWAPIBaseUrl = _config.GetValue<string>("SWAPIBaseUrl");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(SWAPIBaseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetStringAsync($"people/?page={PageNumber}");
            var publicSWresult = JsonSerializer.Deserialize<ResponseSW>(response.ToString(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return publicSWresult;
        }

        public async Task<ResponseDownload> GetProtectedStarWarsMovie(int PageNumber)
        {
            var SWAPIBaseUrl = _config.GetValue<string>("SWAPIBaseUrl");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(SWAPIBaseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetStringAsync($"people/?page={PageNumber}");
            var protectedSWresult = JsonSerializer.Deserialize<ResponseDownload>(response.ToString(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return protectedSWresult;
        }
    }
}

    