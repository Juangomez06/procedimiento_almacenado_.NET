using procedimientos_almacenados_API;
using procedimientos_almacenados_API.Servicios;
using Prometheus;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexión a la base de datos
builder.Services.AddSqlServer<PruebaContext>(
    "Data Source=localhost;Database=pruebas;User Id=sa;Password=123456789;TrustServerCertificate=True"
);

//Prometheus
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.AllowSynchronousIO = true;
});


// Instanciar clase de servicios para inyectarla en los controladores
builder.Services.AddScoped<IEmpleadoServicios, EmpleadoServicios>();

var app = builder.Build();

// Configuración para el entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHttpMetrics();
app.MapMetrics();

app.MapControllers();


app.Run();
