using billetera.Context;
using billetera.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inyecion de dependencia 
//builder.Services.AddSqlServer<DeudasContext>(builder.Configuration.GetConnectionString("cnBilleteraSQLSERVER"));
//builder.Services.AddSqlServer<ObjetivosCompraContext>(builder.Configuration.GetConnectionString("cnBilleteraSQLSERVER"));
//builder.Services.AddSqlServer<PagosContext>(builder.Configuration.GetConnectionString("cnBilleteraSQLSERVER"));

builder.Services.AddOracle<UsuariosContext>(builder.Configuration.GetConnectionString("cnBilleteraORACLE"));
//builder.Services.AddScoped<IDeudasService, DeudasService>();
//builder.Services.AddScoped<IObjetivosCompraService, ObjetivosCompraService>();
//builder.Services.AddScoped<IPagosService, PagosService>();
builder.Services.AddScoped<IUsuariosService, UsuariosService>();

var app = builder.Build();

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

