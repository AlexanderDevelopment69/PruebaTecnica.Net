using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.DB;
using PruebaTecnica.Entity;

namespace PruebaTecnica.Controllers;

[Route("api/movie")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly ApplicationDbContext context;

    public MovieController(ApplicationDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
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

}