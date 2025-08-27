var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

//para encontrar os controllers é necessário adicionar essa linha de cod
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//necessário tbm adicionar essa
app.MapControllers();

app.Run();
