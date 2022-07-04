using Microsoft.EntityFrameworkCore;
using CinemaWebAPI.Context;
using CinemaWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var serverString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddDbContext<AppDbContext>(options => options
                                    .UseLazyLoadingProxies()
                                    .UseMySql(serverString, serverVersion)
                                    .LogTo(Console.WriteLine, LogLevel.Information)
                                    .EnableSensitiveDataLogging());

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<FilmeService, FilmeService>();
builder.Services.AddScoped<CinemaService, CinemaService>();
builder.Services.AddScoped<EnderecoService, EnderecoService>();
builder.Services.AddScoped<GerenteService, GerenteService>();
builder.Services.AddScoped<SessaoService, SessaoService>();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();