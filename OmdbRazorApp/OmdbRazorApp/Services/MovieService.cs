using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;


public class MovieService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "81b7ba53";

    public MovieService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    //metodo de busca do filme
    public async Task<List<Movie>> SearchMovieAsync(string title, string type, string year = null)
    {
        var url = $"https://www.omdbapi.com/?s={title}&type={type}&y={year}&apikey={_apiKey}";

        if (!string.IsNullOrEmpty(type))
            url += $"&type={type}";

        if (!string.IsNullOrEmpty(year))
            url += $"&y={year}";

        //importar nuget System.Net.Http.Json
        var response = await _httpClient.GetFromJsonAsync<ApiResponse>(url);

        return response?.Search ?? new List<Movie>();
    }

}


public record Movie(string Title, string Year, string imdbID, string Poster, string Type);
public record ApiResponse(List<Movie> Search, string totalResults, string Response);