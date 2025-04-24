using Microsoft.AspNetCore.Mvc;
using MoviesSita.Application.IServices;
using MoviesSita.Domain.Entities;
using System.Net;

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
            try
            {
                var filme = await _moviesService.GetMovieById(id);
                return filme;

            }
            catch (Exception err)
            {
                return NotFound($"Movie not found by Id {id}");
            }            
        }

        [HttpGet("GetPaginatedWithFilters")]
        public async Task<PagedItens> MoviesPaginatedWithFilters(string? genrer, string? status, bool adult, int page, int perPage, string? title)
        {
            var genresList = await _moviesService.GetMoviesPaginatedWithFilters(genrer, status, adult, page, perPage, title);
            return genresList;
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteMoviesById(int id)
        {
            try
            {
                return Ok(await _moviesService.DeleteMovieById(id));
            }
            catch (Exception err)
            {
                return NotFound(err.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> InsertMovie(Movies movie)
        {
            try
            {
                return Ok(await _moviesService.InsertMovie(movie));
            }
            catch(Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateMovie(int id, Movies movie)
        {
            try {
                return Ok(await _moviesService.UpdateMovie(id, movie));
            }
            catch (Exception err)
            {
               return BadRequest(err.Message);
            }
        }
    }
}
