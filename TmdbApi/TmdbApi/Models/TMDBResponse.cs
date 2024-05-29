namespace TmdbApi.Models
{
public class TMDBResponse
{
    public int Page { get; set; }
    public Movie[] Results { get; set; }
    public int TotalPages { get; set; }
    public int TotalResults { get; set; }
}
}
