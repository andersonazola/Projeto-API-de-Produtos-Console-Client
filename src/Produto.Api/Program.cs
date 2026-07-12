using Produto.Repositorio;
using Microsoft.EntityFrameworkCore;
using Produto.Aplicacao;
using Produto.Dominio.Interfaces;
using Produto.Repositorio.Repositorio;
using Produto.Repositorio.Context;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Adicione servicos ao contêiner
builder.Services.AddScoped<IProdutoAplicacao, ProdutoAplicacao>();


// Adicione as interfaces de banco de dados
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();


// Adicione os servicos

// builder.Services.AddScoped<> 

builder.Services.AddControllers();


// Adicionar o serviço de banco de dados

builder.Services.AddDbContext<ProdutoContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("ProdutoDB")));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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


