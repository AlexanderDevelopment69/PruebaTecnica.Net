using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PruebaTecnica.Controllers;
using PruebaTecnica.DB;
using PruebaTecnica.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlite("Data Source=DB/DataBase.db"));
//
builder.Services.AddEntityFrameworkSqlite().AddDbContext<ApplicationDbContext>();
//INYECCION
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //Cors
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    app.UseHttpsRedirection(); 
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();