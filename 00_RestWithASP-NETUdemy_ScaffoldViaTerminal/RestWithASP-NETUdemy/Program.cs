using EvolveDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using MySqlConnector;

using RestWithASP_NETUdemy.Model.Context;
using RestWithASP_NETUdemy.Repository;
using RestWithASP_NETUdemy.Repository.Generic;
using RestWithASP_NETUdemy.Services;
using RestWithASP_NETUdemy.Services.Implementations;
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
builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();
builder.Services.AddScoped<IBookService, BookServiceImplementation>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

//passar parametros para o header, podendo trocar o retorno entre xml e json
builder.Services.AddMvc(options =>
{
    options.RespectBrowserAcceptHeader = true;
    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
    options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
})
.AddXmlSerializerFormatters();

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
