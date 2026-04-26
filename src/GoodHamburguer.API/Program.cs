using Microsoft.EntityFrameworkCore;
using GoodHamburguer.Application;
using GoodHamburguer.Infrastructure;
using GoodHamburguer.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<GoodHamburguer.Infrastructure.Data.AppDbContext>();
        db.Database.Migrate();
    }
    catch (Exception ex)
    {
        // In production, replace with proper logging
        Console.WriteLine("An error occurred while migrating the database: " + ex.Message);
        throw;
    }
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
