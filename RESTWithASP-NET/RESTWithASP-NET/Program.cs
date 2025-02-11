using Microsoft.EntityFrameworkCore;
using RESTWithASP_NET.Model.Context;
using RESTWithASP_NET.Business.Implementations;
using RESTWithASP_NET.Business;
using RESTWithASP_NET.Repository;
using RESTWithASP_NET.Repository.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];

builder.Services.AddDbContext<MySQLContext>(options => 
                                                options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

builder.Services.AddApiVersioning();

builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
