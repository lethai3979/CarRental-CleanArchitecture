using API.Authentication;
using Application;
using Application.Abstraction.Authentication;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SQLServer;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration
                        .GetConnectionString("DefaultConnection")
                        ?? throw new InvalidOperationException("Connection String not found");

// Add services to the container.
builder.Services.AddScoped<IJWTProvider, JWTProvider>();
builder.Services.AddApplication();
builder.Services.AddSQLServer(connection);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Other existing code


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
