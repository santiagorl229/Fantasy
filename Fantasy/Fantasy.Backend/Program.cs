using Fantasy.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Fantasy API",
        Version = "v1",
        Description = "API para Fantasy App"
    });

    // ✅ Agrega el servidor base aquí
    options.AddServer(new OpenApiServer
    {
        Url = "https://localhost:7165", // Cambia esto según el puerto de tu API
        Description = "Servidor local de desarrollo"
    });
});

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=LocalConection"));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();