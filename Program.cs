using billetera.Context;
using billetera.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inyecion de dependencia 
builder.Services.AddSqlServer<DeudasContext>(builder.Configuration.GetConnectionString("cnBilletera"));
builder.Services.AddSqlServer<ObjetivosCompraContext>(builder.Configuration.GetConnectionString("cnBilletera"));
builder.Services.AddSqlServer<PagosContext>(builder.Configuration.GetConnectionString("cnBilletera"));
builder.Services.AddSqlServer<UsuariosContext>(builder.Configuration.GetConnectionString("cnBilletera"));

builder.Services.AddScoped<IDeudasService, DeudasService>();
builder.Services.AddScoped<IObjetivosCompraService, ObjetivosCompraService>();
builder.Services.AddScoped<IPagosService, PagosService>();
builder.Services.AddScoped<IUsuariosService, UsuariosService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
