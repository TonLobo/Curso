using Microsoft.AspNetCore.Mvc;
using TmdbApi.Services;

namespace TmdbApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly TMDBService _tmdbService;
        private object? movieDetails;

        public MoviesController(TMDBService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        [HttpGet("popular")]
        public async Task<IActionResult> GetMovieDetails(int movieId)
        {
            var movies = await _tmdbService.GetMovieDetailsAsync(movieId);
            return Ok(movieDetails);
        }
    }
}
