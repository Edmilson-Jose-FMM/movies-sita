using MoviesSita.Application.IServices;
using MoviesSita.Domain.Entities;
using MoviesSita.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Internal;
namespace MoviesSita.Application.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly MoviesDbContext _moviesDbContext;
        public MoviesService(MoviesDbContext moviesDbContext)
        {
            _moviesDbContext = moviesDbContext;
        }

        public async Task<ActionResult<Movies>> GetMovieById(long id)
        {
            var movie = await _moviesDbContext.movies.FindAsync(id);

            if (movie == null)
                throw new Exception($"Movie not found by ID: {id}");
            
            return movie;
        }
        public async Task<PagedItens> GetMoviesPaginatedWithFilters(string? genrer, string? status, bool adult, int page, int perPage,string? title)
        {
            PagedItens pagedItens = new PagedItens(); 
            var result = _moviesDbContext.movies.AsQueryable();

            if (status != null)
            {
                result = result.Where(p => EF.Functions.ILike(p.status, $"{status}%") ||
                                           p.status == status);
            }
            if (genrer != null)
            {
                result = result.Where(p=>
                                           EF.Functions.ILike(p.genres, $"%{genrer},%") || 
                                           EF.Functions.ILike(p.genres, $"%{genrer}") ||  
                                           EF.Functions.ILike(p.genres, $"{genrer},%") ||  
                                           p.genres == genrer);
            }
            if (adult != null)
            {
                result = result.Where(p => p.adult == adult);
            }
            if (status != null)
            {
                result = result.Where(p => EF.Functions.ILike(p.status, $"{status}%") ||
                                           p.status == status);
            }
            if (page == 0 && perPage == 0)
            {
                page = 1;
                perPage = 10;
            }
            
            result = result.Skip((page - 1) * perPage).Take(perPage);
            
            pagedItens.Movies = await result.AsNoTracking().ToListAsync();
            pagedItens.Page = page;
            pagedItens.PerPage = perPage;

            return pagedItens;

        }

        public async Task<bool> DeleteMovieById(long id)
        {
            var movie = await _moviesDbContext.movies.FindAsync(id);

            if (movie == null)
                  throw new Exception("Movie not found to be deleted");
            _moviesDbContext.movies.Remove(movie);
            await _moviesDbContext.SaveChangesAsync();

            return true;
        }
        public async Task<string> InsertMovie(Movies movie)
        {

            if (movie.title == null)
                throw new Exception("Title field cannot be empty");
            movie.id = _moviesDbContext.movies.Max(f => f.id)+1;
            await _moviesDbContext.movies.AddAsync(movie);
            _moviesDbContext.SaveChanges();

            return $"Movie added with ID:{movie.id}";

        }
        public async Task<bool> UpdateMovie(long id, Movies movie)
        {
            try
            {
                if (movie.id == null)
                    throw new Exception("Id field cannot be empty");

                var updatedMovie = await _moviesDbContext.movies.FindAsync(id);
                if (updatedMovie == null)
                    throw new Exception($"Movie not found by id: {id}. Cannot by updated");

                #region Updating registry
                updatedMovie.title = movie.title;
                updatedMovie.vote_average = movie.vote_average;
                updatedMovie.vote_count = movie.vote_count;
                updatedMovie.status = movie.status;
                updatedMovie.release_date = movie.release_date;
                updatedMovie.revenue = movie.revenue;
                updatedMovie.runtime = movie.runtime;
                updatedMovie.adult = movie.adult;
                updatedMovie.backdrop_path = movie.backdrop_path;
                updatedMovie.budget = movie.budget;
                updatedMovie.homepage = movie.homepage;
                updatedMovie.imdb_id = movie.imdb_id;
                updatedMovie.original_language = updatedMovie.original_language;
                updatedMovie.original_title = updatedMovie.original_title;
                updatedMovie.overview = movie.overview;
                updatedMovie.popularity = movie.popularity;
                updatedMovie.poster_path = movie.poster_path;
                updatedMovie.overview = movie.tagline;
                updatedMovie.popularity = movie.popularity;
                updatedMovie.poster_path = movie.poster_path;
                updatedMovie.tagline = movie.tagline;
                updatedMovie.genres = movie.genres;
                updatedMovie.production_companies = movie.production_companies;
                updatedMovie.production_countries = movie.production_countries;
                updatedMovie.spoken_languages = movie.spoken_languages;
                updatedMovie.keywords = movie.keywords;
                #endregion
                _moviesDbContext.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                throw new Exception("Error while updating the movie");
            }
        }
    }
}
