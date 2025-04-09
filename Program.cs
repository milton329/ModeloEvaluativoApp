using Microsoft.EntityFrameworkCore;
using Back;

var builder = WebApplication.CreateBuilder(args);

// Lee la cadena de conexión desde la configuración
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registra el DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Agrega servicios MVC (controladores + vistas)
builder.Services.AddControllersWithViews();

// Swagger (opcional si solo estás usando MVC, pero útil para probar la API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware para desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware de seguridad y archivos estáticos
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Mapea controladores con vistas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ModeloEvaluativo}/{action=Index}/{id?}");

app.Run();
