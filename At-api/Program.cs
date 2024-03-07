using At_api.Data;
using At_api.Repositorio;
using At_api.Repositorio.interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IProdutosRepositorio, ProdutosRepositorio>();
builder.Services.AddScoped<ICategoriasRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<IPedidosRepositorio, PedidosRepositorio>();
builder.Services.AddScoped<IPedidoProdutosRepositorio, PedidosProdutosRepositorio>();


builder.Services.AddDbContext<At_apiDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
    );

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
