using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TmdbApi.Models;

namespace TmdbApi.Services
{
    public class TMDBService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "51ee6e3b5b22fd54fe9d6c282290f7a0";

        public TMDBService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TMDBResponse> GetMovieDetailsAsync(int movieId)
        {
            var response = await _httpClient.GetFromJsonAsync<TMDBResponse>($"https://api.themoviedb.org/3/movie/popular?api_key={_apiKey}");
            return response;
        }
    }
}
