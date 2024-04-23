using bco.atlantidad.estadocuenta.api.Core.DTO;
using bco.atlantidad.estadocuenta.api.Core.Logic.Bussines;
using bco.atlantidad.estadocuenta.api.Core.Logic.Interface;
using bco.atlantidad.estadocuenta.api.Core.Logic.Repository;
using bco.atlantidad.estadocuenta.api.Infraestructura.Data;
using bco.atlantidad.estadocuenta.api.Infraestructura.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ConnectionString>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddTransient<IDapperContext, DapperContext>();
builder.Services.AddTransient<ICliente, ClienteRepositorio>();
builder.Services.AddTransient<ITarjeta, TarjetaRepositorio>();
builder.Services.AddTransient<IEstadoCuenta, EstadoCuentaRepositorio>();
builder.Services.AddTransient<IMovimientos, MovimientoRepositorio>();
builder.Services.AddTransient<IConfiguraciones, ConfiguracionRepositorio>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IMovimientosNegocio, MovimientosNegocio>();
builder.Services.AddTransient<IEstadoCuentaNegocio, EstadoCuentaNegocio>();
builder.Services.AddTransient<IConfiguracionesNegocio, ConfiguracionesNegocio>();


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
