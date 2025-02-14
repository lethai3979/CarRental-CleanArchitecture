using API.OptionSetup;
using Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using SQLServer;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration
                        .GetConnectionString("DefaultConnection")
                        ?? throw new InvalidOperationException("Connection String not found");

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddSQLServer(connection);
builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.ConfigureOptions<JWTOptionSetup>();
builder.Services.ConfigureOptions<JWTBearerOptionSetup>();



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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
