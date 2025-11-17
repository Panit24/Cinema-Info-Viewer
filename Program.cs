using Microsoft.EntityFrameworkCore;
using Cinema_Info_Viewer.Models.DbMiracle;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Hosting.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<MiracleDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MiracleDb")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS if needed
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

// Log the URLs the app is listening on
app.Lifetime.ApplicationStarted.Register(() =>
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    var addresses = app.Services.GetRequiredService<IServer>().Features
        .Get<IServerAddressesFeature>()?.Addresses;

    if (addresses != null)
    {
        logger.LogInformation("==================================================");
        logger.LogInformation("Application started successfully!");
        logger.LogInformation("Environment: {Environment}", app.Environment.EnvironmentName);
        logger.LogInformation("Application is listening on:");
        foreach (var address in addresses)
        {
            logger.LogInformation("  - {Address}", address);
        }
        logger.LogInformation("Swagger UI: {SwaggerUrl}", $"{addresses.FirstOrDefault()}/swagger");
        logger.LogInformation("API Endpoint: {ApiUrl}", $"{addresses.FirstOrDefault()}/api/content");
        logger.LogInformation("==================================================");
    }
});

app.Run();
