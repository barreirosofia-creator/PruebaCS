using SistemaVentas.Components;
using SistemaVentas.Services;
using SistemaVentas.Models;
using SistemaVentas.Services.IRepository;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<IConsultaVentasService, ConsultaVentasService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["urlLocalHost"]);
});
builder.Services.AddDbContext<SistemaVentasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IConexionDbService, ConexionDbService>();


builder.Services.AddSingleton<IEmpleadoApiService, EmpleadoApiService>();
builder.Services.AddSingleton<IStatusApiService, StatusApiService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SistemaVentas API v1");
        c.RoutePrefix = "swagger"; // Accedés desde /swagger
    });
}
else
{

    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseAntiforgery();


app.MapControllers();
app.Run();

