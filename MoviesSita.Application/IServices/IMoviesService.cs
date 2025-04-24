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
        Task<ActionResult<Movies>> GetMovieById(int id);
        Task<PagedItens> GetMoviesPaginatedWithFilters(string? genrer, string? status, bool adult, int page, int perPage, string? title);
        Task<bool> DeleteMovieById(int id);
        Task<bool> UpdateMovie(int id, Movies movie);
        Task<bool> InsertMovie(Movies movie);
    }
}
