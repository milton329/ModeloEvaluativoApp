using Microsoft.EntityFrameworkCore;
using Back;

var builder = WebApplication.CreateBuilder(args);

// Lee la cadena de conexi�n desde la configuraci�n
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registra el DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Agrega servicios MVC (controladores + vistas)
builder.Services.AddControllersWithViews();

// Swagger (opcional si solo est�s usando MVC, pero �til para probar la API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware para desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware de seguridad y archivos est�ticos
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Mapea controladores con vistas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ModeloEvaluativo}/{action=Index}/{id?}");

app.Run();
