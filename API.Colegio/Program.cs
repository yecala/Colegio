using BM.Colegio.Interfaces;
using BM.Colegio.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Esto es para que permita hacer la inyeccion de dependencias en el controlador,
//cada que se cree un servicio que herede de una interfaz toca hacer esto
builder.Services.AddScoped<IEstudiante,EstudianteServicio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
