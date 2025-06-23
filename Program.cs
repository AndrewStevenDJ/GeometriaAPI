using GeometriaAPI.Data;
using GeometriaAPI.Service;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Configura la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Agrega DbContext con MySQL
builder.Services.AddDbContext<GeometriaContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// Registra tus servicios
builder.Services.AddScoped<TrianguloService>();
builder.Services.AddScoped<RectanguloService>();
builder.Services.AddScoped<CuadradoService>();
builder.Services.AddScoped<CirculoService>();

// Agrega controladores
builder.Services.AddControllers();

// Swagger para documentación API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware para Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
