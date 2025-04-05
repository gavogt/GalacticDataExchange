using AlienDataSignalR;
using GalacticDataExchange.Shared;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSignalR();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: true)
    .Build();

builder.Services.AddDbContext<DataDBContext>(options =>
options.UseSqlServer(configuration.GetConnectionString("AlienConnection")));

builder.Services.AddScoped<ISensorReadingService, SensorReadingService>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapHub<SensorHub>("/sensorHub");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
