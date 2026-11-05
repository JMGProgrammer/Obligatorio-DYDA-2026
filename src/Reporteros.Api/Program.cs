using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Reporteros.Api.Data;
using Reporteros.Api.Interfaces;
using Reporteros.Api.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddHealthChecks();

// Autenticacion JWT (para Web y futuro cliente movil).
var jwtKey = builder.Configuration["Jwt:Key"] ?? "ReporterosDevSigningKey_AtLeast32CharsLong!!";
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"] ?? "Reporteros",
            ValidAudience = builder.Configuration["Jwt:Audience"] ?? "Reporteros",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });
builder.Services.AddAuthorization();

// Persistencia: MySQL via Pomelo (proveedor EF Core). La cadena de conexion
// se toma de Configuration (User Secrets en desarrollo, variables en produccion).
var cadenaConexion = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Falta la cadena de conexion 'DefaultConnection'.");

builder.Services.AddScoped<ICompeticionService, CompeticionService>();
builder.Services.AddScoped<ITemporadaService, TemporadaService>();
builder.Services.AddScoped<IEquipoService, EquipoService>();
builder.Services.AddScoped<IPartidoService, PartidoService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(cadenaConexion, ServerVersion.AutoDetect(cadenaConexion),
        mysql => mysql.EnableRetryOnFailure()));

builder.Services.AddScoped<IArticuloService, ArticuloService>();
builder.Services.AddScoped<IDeporteService, DeporteService>();
builder.Services.AddScoped<IStandingsService, StandingsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapHealthChecks("/health");
app.MapControllers();

app.Run();
