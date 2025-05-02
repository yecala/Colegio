using BM.Colegio.Interfaces;
using BM.Colegio.Servicios;
using DA.Colegio;
using DA.Colegio.Interfaz;
using DA.Colegio.Repositorios;
using DT.Colegio.Modelos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add servicios to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Esto es para que permita hacer la inyeccion de dependencias en el controlador,
//cada que se cree un servicio que herede de una interfaz toca hacer esto
// Registrar repositorios genéricos y específicos
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IDocenteRepositorio, DocenteRepositorio>();
builder.Services.AddScoped<IEstudianteRepositorio, EstudianteRepositorio>();
builder.Services.AddScoped<IGradoRepositorio, GradoRepositorio>();
builder.Services.AddScoped<IMateriaRepositorio, MateriaRepositorio>();
builder.Services.AddScoped<IEstudianteGradoRepositorio, EstudianteGradoRepositorio>();
builder.Services.AddScoped<IMateriaPorGradoRepositorio, MateriaPorGradoRepositorio>();
builder.Services.AddScoped<INotaRepositorio, NotaRepositorio>();
builder.Services.AddScoped<ITransactionCoordinatorUnitOfWork, TransactionCoordinatorUnitOfWork>();

// Registrar servicios genéricos y específicos
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IDocenteServicio, DocenteServicio>();
builder.Services.AddScoped<IEstudianteServicio, EstudianteServicio>();
builder.Services.AddScoped<IGradoServicio, GradoServicio>();
builder.Services.AddScoped<IMateriaServicio, MateriaServicio>();
builder.Services.AddScoped<IEstudianteGradoServicio, EstudianteGradoServicio>();
builder.Services.AddScoped<IMateriaPorGradoServicio, MateriaPorGradoServicio>();
builder.Services.AddScoped<INotaServicio, NotaServicio>();



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
