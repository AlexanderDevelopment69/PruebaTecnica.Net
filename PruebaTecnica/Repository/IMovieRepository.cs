using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Controllers;
using PruebaTecnica.Model;

namespace PruebaTecnica.Repository;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetMovies();
    Task<Movie> GetMovie(int movieId);
    Task<Movie> AddMovie(Movie movie);
    Task<Movie> UpdateMovie(Movie movie);
    Task<Movie> DeleteMovie(int movieId);
    

}