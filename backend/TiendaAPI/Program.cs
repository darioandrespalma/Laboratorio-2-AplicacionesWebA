using Microsoft.EntityFrameworkCore;
using TiendaAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. CONFIGURAR LA CONEXIÓN A BASE DE DATOS (ESTO ES LO QUE FALTABA)
// Lee la cadena de conexión del archivo appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registra el DbContext para que PostgreSQL funcione
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// 2. Servicios básicos de la API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. Configurar CORS (Para que Angular pueda conectarse después)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// Configuración del pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngular"); // Activar los permisos para Angular

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();