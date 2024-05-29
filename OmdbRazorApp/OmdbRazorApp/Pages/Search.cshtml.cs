using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OmdbRazorApp.Pages;

public class SearchModel(MovieService movieService) : PageModel
{
    private readonly MovieService _movieService = movieService;

    public List<Movie> Movies { get; private set; } = new List<Movie>();

    [BindProperty(SupportsGet = true)]
    public string Title { get; set; }

    [BindProperty(SupportsGet = true)]
    public string Type { get; set; }

    [BindProperty(SupportsGet = true)]
    public string Year { get; set; }

    public async Task GetTaskAsync()
    {
        if (!string.IsNullOrEmpty(Title))
        {
            Movies = await _movieService.SearchMovieAsync(Title, Type, Year);
        }
    }
}
