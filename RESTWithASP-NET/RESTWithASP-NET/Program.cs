using Microsoft.EntityFrameworkCore;
using RESTWithASP_NET.Model.Context;
using RESTWithASP_NET.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];

builder.Services.AddDbContext<MySQLContext>(options => 
                                                options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

builder.Services.AddApiVersioning();

builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
