using Microsoft.AspNetCore.Mvc;
using MoviesSita.Application.IServices;
using MoviesSita.Domain.Entities;

namespace MoviesSita.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;
        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }
        [HttpGet("GetById")]
        public async Task<ActionResult<Movies>> MoviesGet(int id)
        {

            var filme = await _moviesService.GetMovieById(id);
            if (filme == null)
            {
                return NotFound();
            }
            return filme;
        }

        [HttpGet("GetPaginatedWithFilters")]
        public async Task<ActionResult<IEnumerable<Movies>>> MoviesPaginatedWithFilters(string genrer, string status, bool adult, int page, int perPage)
        {
            var genresList = await _moviesService.GetMoviesByGenresPaginated(genrer, status, adult, page, perPage);
            return genresList;
        }

        [HttpDelete]
        public async Task<bool> DeleteMoviesById(int id)
        {
            try
            {
                return await _moviesService.DeleteMovieById(id);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
        [HttpPost]
        public async Task<bool> InsertMovie(Movies movie)
        {
            return await _moviesService.InsertMovie(movie);
             
        }

        [HttpPut]
        public async Task<bool> UpdateMovie(int id, Movies movie)
        {
            return await _moviesService.UpdateMovie(id, movie);
        }
    }
}
