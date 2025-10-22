using Microsoft.EntityFrameworkCore;
using SGE.Api.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ----------------------------
// Configuración de servicios
// ----------------------------

// Agregar DbContext con SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar controladores
builder.Services.AddControllers();

// Habilitar CORS para Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Agregar soporte para OpenAPI/Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "SGE API",
        Description = "API de gestión de empleados"
    });
});

var app = builder.Build();

// ----------------------------
// Pipeline de la app
// ----------------------------

// Usar CORS
app.UseCors("AllowAngularApp");

// Redirección HTTPS
app.UseHttpsRedirection();

// Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SGE API v1");
        c.RoutePrefix = string.Empty; // Para abrir Swagger en la raíz del proyecto
    });
}

// Mapear controladores
app.MapControllers();

app.Run();
