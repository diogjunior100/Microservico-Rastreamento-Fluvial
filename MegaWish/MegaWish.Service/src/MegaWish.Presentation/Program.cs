using Microsoft.EntityFrameworkCore;
using MegaWish.Application.Interfaces;
using MegaWish.Application.Services;
using MegaWish.Domain.Interfaces;
using MegaWish.Infrastructure.Context;
using MegaWish.Infrastructure.Repositories;
using System.Reflection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "Rastreamento Fluvial API", Version = "v1" });
});

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("DataSource=:memory:"));

builder.Services.AddScoped<ZonaRepositoryInterface, ZonaRepository>();
builder.Services.AddScoped<RastreamentoRepositoryInterface, RastreamentoRepository>();
builder.Services.AddScoped<ZonaServiceInterface, ZonaService>();
builder.Services.AddScoped<RastreamentoServiceInterface, RastreamentoService>();

builder.WebHost.UseUrls("http://0.0.0.0:80");

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.OpenConnection();
    context.Database.EnsureCreated();
}

app.MapGet("/", () => "Hello World!");

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
