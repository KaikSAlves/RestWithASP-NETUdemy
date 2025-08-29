using EvolveDb;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using RestWithASP_NETUdemy.Business;

using RestWithASP_NETUdemy.Business.Implementations;

using RestWithASP_NETUdemy.Model.Context;
using RestWithASP_NETUdemy.Repository;
using RestWithASP_NETUdemy.Repository.Generic;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
IWebHostEnvironment env = builder.Environment;
Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

                                            //services
builder.Services.AddOpenApi();
builder.Services.AddCors();

//versionamento de api
builder.Services.AddApiVersioning();

//para encontrar os controllers é necessário adicionar essa linha de cod
builder.Services.AddControllers();

//para injeção de dependência
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<MySqlContext>(options => options.UseMySql(connection,
    new MySqlServerVersion(new Version(8,4,6))));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    MigrateDatabase(connection);
}

app.UseHttpsRedirection();
//necessário tbm adicionar essa
app.MapControllers();

app.Run();


void MigrateDatabase(string connection)
{
    try
    {
        var evolveConnection = new MySqlConnection(connection);
        var evolve = new Evolve(evolveConnection, Log.Information)
        {
            Locations = new List<string> { "db/migrations", "db/dataset" },
            IsEraseDisabled = true
        };

        evolve.Migrate();
    }
    catch (Exception e)
    {
        Log.Error("Database migration failed ", e);
        throw;
    }
}
