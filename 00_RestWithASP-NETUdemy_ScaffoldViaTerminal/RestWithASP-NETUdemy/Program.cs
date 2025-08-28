using Microsoft.EntityFrameworkCore;
using RestWithASP_NETUdemy.Model.Context;
using RestWithASP_NETUdemy.Services;
using RestWithASP_NETUdemy.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddCors();

//para encontrar os controllers é necessário adicionar essa linha de cod
builder.Services.AddControllers();
//para injeção de dependência
builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<MySqlContext>(options => options.UseMySql(connection,
    new MySqlServerVersion(new Version(8,4,6))));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}



app.UseHttpsRedirection();
//necessário tbm adicionar essa
app.MapControllers();

app.Run();
