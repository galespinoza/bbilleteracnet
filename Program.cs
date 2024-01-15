using billetera.Context;
using billetera.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inyecion de dependencia 

//-------------------------------
//Entity Framework SQL SERVER
//-------------------------------
//builder.Services.AddSqlServer<DeudasContext>(builder.Configuration.GetConnectionString("cnBilleteraSQLSERVER"));
//builder.Services.AddSqlServer<ObjetivosCompraContext>(builder.Configuration.GetConnectionString("cnBilleteraSQLSERVER"));
//builder.Services.AddSqlServer<PagosContext>(builder.Configuration.GetConnectionString("cnBilleteraSQLSERVER"));
//builder.Services.AddSqlServer<UsuariosContext>(builder.Configuration.GetConnectionString("cnBilleteraSQLSERVER"));
//-------------------------------

//-------------------------------
//Entity Framework ORACLE
//-------------------------------
//builder.Services.AddOracle<DeudasContext>(builder.Configuration.GetConnectionString("cnBilleteraORACLE"));
//builder.Services.AddOracle<ObjetivosCompraContext>(builder.Configuration.GetConnectionString("cnBilleteraORACLE"));
//builder.Services.AddOracle<PagosContext>(builder.Configuration.GetConnectionString("cnBilleteraORACLE"));
//builder.Services.AddOracle<UsuariosContext>(builder.Configuration.GetConnectionString("cnBilleteraORACLE"));
//-------------------------------

//-------------------------------
//Entity Framework POSTGRE
//-------------------------------
//builder.Services.AddOracle<DeudasContext>(builder.Configuration.GetConnectionString("cnBilleteraORACLE"));
//builder.Services.AddOracle<ObjetivosCompraContext>(builder.Configuration.GetConnectionString("cnBilleteraORACLE"));
//builder.Services.AddOracle<PagosContext>(builder.Configuration.GetConnectionString("cnBilleteraORACLE"));

builder.Services.AddDbContext<UsuariosContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("cnBilleteraPOSTGRE")));
//-------------------------------


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

