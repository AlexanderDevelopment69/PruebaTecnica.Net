using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.DB;
using PruebaTecnica.Model;
using PruebaTecnica.Repository;

namespace PruebaTecnica.Controllers;

public class MovieRepository : IMovieRepository
{
    private readonly ApplicationDbContext context;


    public MovieRepository(ApplicationDbContext context)
    {
        this.context = context;
    }
    

    public async Task<IEnumerable<Movie>> GetMovies()
    {
        return await context.Movies.ToListAsync();
    }

    public async Task<Movie> GetMovie(int movieId)
    {
        return await context.Movies.FirstOrDefaultAsync(e => e.id == movieId);
    }

    public async Task<Movie> AddMovie(Movie movie)
    {
        var result= await context.Movies.AddAsync(movie);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Movie> UpdateMovie(Movie movie)
    {
        var result = await context.Movies
            .FirstOrDefaultAsync(e => e.id == movie.id);

        if (result != null)
        {
            result.titulo = movie.titulo;
            result.director = movie.director;
            result.genero = movie.genero;

            await context.SaveChangesAsync();

            return result;
        }

        return null;
    }

    public async Task<Movie> DeleteMovie(int movieId)
    {
        var result = await context.Movies
            .FirstOrDefaultAsync(e => e.id == movieId);
        if (result != null)
        {
            context.Movies.Remove(result);
            await context.SaveChangesAsync();
        }
        return result;
    }
    
   // public void ConfigureServices(IServiceCollection services)
   // {
   //     services.AddScoped<IMovieRepository, MovieRepository>();
    //}
}