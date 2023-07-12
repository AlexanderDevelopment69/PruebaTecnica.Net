using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Model;


namespace PruebaTecnica.DB;

public class ApplicationDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 {
     optionsBuilder.UseSqlite("Data Source=DataBase/DB.db");
 }
    /*  public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }
    */

 public DbSet<Movie> Movies { get; set; }
}