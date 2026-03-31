using api;
using api.services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddJsonOptions(o =>
    {
        o.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        o.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;

    });
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=services.db"));

builder.Services.AddScoped<ServicoService>();



const string CorsPolicy = "CorsDev";
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(CorsPolicy, policy =>
        policy
            .WithOrigins(
                "http://127.0.0.1:5500/",
                "http://localhost:5000"
                // aqui adiciona a url do site
            )
            .SetIsOriginAllowedToAllowWildcardSubdomains()
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
    );
});

var app = builder.Build();
app.UseCors("CorsDev");

// Configure the HTTP request pipeline.

    app.MapOpenApi();
    app.MapScalarApiReference(options => 
    {
        options.WithOpenApiRoutePattern("/openapi/v1.json"); // Força o caminho do documento
    });


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
