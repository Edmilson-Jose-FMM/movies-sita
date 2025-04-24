using Microsoft.AspNetCore.Mvc;
using MoviesSita.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesSita.Application.IServices
{ 
    public interface IMoviesService
    {
        Task<ActionResult<Movies>> GetMovieById(long id);
        Task<PagedItens> GetMoviesPaginatedWithFilters(string? genrer, string? status, bool adult, int page, int perPage, string? title);
        Task<bool> DeleteMovieById(long id);
        Task<bool> UpdateMovie(long id, Movies movie);
        Task<string> InsertMovie(Movies movie);
    }
}
