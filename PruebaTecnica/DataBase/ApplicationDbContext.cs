using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Entity;

namespace PruebaTecnica.DB;

public class ApplicationDbContext : DbContext
{
  

/*  public ApplicationDbContext(DbContextOptions options) : base(options)
 {
     
 }
 */

 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 {
     optionsBuilder.UseSqlite("Data Source=DataBase/DB.db");
 }
 
 public DbSet<Movie> Movies { get; set; }
}