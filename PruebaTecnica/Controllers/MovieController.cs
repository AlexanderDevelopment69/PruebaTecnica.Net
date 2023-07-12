
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Model;
using PruebaTecnica.Repository;

namespace PruebaTecnica.Controllers;

[Route("api/movie")]
[ApiController]
public class MovieController : ControllerBase
{
    //private readonly ApplicationDbContext context;
    private readonly IMovieRepository movieRepository;


  //  public MovieController(ApplicationDbContext context)
   // {
   //     this.context = context;
   // }

   public MovieController(IMovieRepository movieRepository)
   {
       this.movieRepository = movieRepository;
   }

   [HttpGet]
   public async Task<ActionResult> GetMovies()
   {
       try
       {
           return Ok(await movieRepository.GetMovies());
       }
       catch (Exception)
       {
           return StatusCode(StatusCodes.Status500InternalServerError, 
               "Error al recuperar datos de la base de datos");
       }
   }
   
   [HttpGet("{id:int}")]
   public async Task<ActionResult<Movie>> GetMovie(int id)
   {
       try
       {
           var result = await movieRepository.GetMovie(id);

           if (result == null) return NotFound();

           return result;
       }
       catch (Exception)
       {
           return StatusCode(StatusCodes.Status500InternalServerError,
               "Error al recuperar datos de la base de datos");
       }
   }

   [HttpPost]
   public async Task<ActionResult<Movie>> CreateMovie(Movie movie)
   {
       try
       {
           if (movie == null)
               return BadRequest();

           var createdMovie = await movieRepository.AddMovie(movie);

           return CreatedAtAction(nameof(GetMovies),
               new { createdMovie.id }, createdMovie);
       }
       catch (Exception)
       {
           return StatusCode(StatusCodes.Status500InternalServerError,
               "Error al crear nueva movie");
       }
   }


   [HttpPut("{id:int}")]
   public async Task<ActionResult<Movie>> UpdateMovie(int id, Movie movie)
   {
       try
       {
           if (id != movie.id)
               return BadRequest("Movie ID mismatch");

           var movieToUpdate = await movieRepository.GetMovie(id);

           if (movieToUpdate == null)
               return NotFound($"Movie con Id = {id} no econtrado");

           return await movieRepository.UpdateMovie(movie);
       }
       catch (Exception)
       {
           return StatusCode(StatusCodes.Status500InternalServerError,
               "Error al actualizar datos");
       }

   }

   [HttpDelete("{id:int}")]
   public async Task<ActionResult<Movie>> DeleteMovie(int id)
   {
       try
       {
           var movieToDelete = await movieRepository.GetMovie(id);

           if (movieToDelete == null)
           {
               return NotFound($"Movie con Id = {id} no contrado");
               
           }

           return await movieRepository.DeleteMovie(id);
       }
       catch (Exception)
       {
           return StatusCode(StatusCodes.Status500InternalServerError,
               "Error al eliminar datos");
       }
   }




   /* [HttpGet]
    public async Task<ActionResult<List<Movie>>> Get()
    {
        return await context.Movies.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult> Post(Movie movie)
    {
        context.Add(movie);
        await context.SaveChangesAsync();
        return Ok();

    }
    
    [HttpPut]
    public async Task<IActionResult> PutAsync(Movie movie)
    {
        context.Movies.Update(movie);
        await context.SaveChangesAsync();
        return NoContent();
    }

    */
    
    
    

}