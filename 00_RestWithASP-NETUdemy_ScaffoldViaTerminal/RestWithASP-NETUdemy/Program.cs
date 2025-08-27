using RestWithASP_NETUdemy.Services;
using RestWithASP_NETUdemy.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddCors();

//para encontrar os controllers é necessário adicionar essa linha de cod
builder.Services.AddControllers();

//para injeção de dependência
builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
//necessário tbm adicionar essa
app.MapControllers();

app.Run();
