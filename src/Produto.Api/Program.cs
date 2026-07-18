using Produto.Repositorio;
using Microsoft.EntityFrameworkCore;
using Produto.Aplicacao;
using Produto.Dominio.Interfaces;
using Produto.Repositorio.Repositorio;
using Produto.Repositorio.Context;


//O início de tudo: Cria o construtor da aplicação
var builder = WebApplication.CreateBuilder(args);

// Adiciona os services ao container.



// Adicione servicos  da aplicação ao contêiner 
// Registra a sua camada de aplicação. 
// Quando o ProdutoController for criado e pedir um IProdutoAplicacao no construtor, o contêiner do .NET vai injetar essa classe automaticamente. Por ser Scoped, ela vai durar apenas o tempo de uma requisição HTTP.
builder.Services.AddScoped<IProdutoAplicacao, ProdutoAplicacao>(); //
 



// Adicione as interfaces de banco de dados
// Faz exatamente a mesma coisa que a linha anterior, mas para a camada de acesso a dados. Quando a sua ProdutoAplicacao pedir o repositório, o .NET entrega a instância pronta.
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();




// Adicione os servicos


// builder.Services.AddScoped<> 




//Ativa o suporte para os Controllers na API. Sem essa linha, o .NET não saberia ler atributos como [ApiController], [HttpGet] ou [HttpPost].
builder.Services.AddControllers();


// Adicionar o serviço de banco de dados
// "Monitore o meu banco de dados usando o contexto ProdutoContext e use o provedor do SQLite". Ele vai até o seu appsettings.json, busca o texto que está na chave "ProdutoDB" e usa como endereço do banco.
builder.Services.AddDbContext<ProdutoContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("ProdutoDB")));




// Contrata os serviços necessários para gerar a documentação automática da sua API. O SwaggerGen lê os seus controllers e métodos para criar aquela interface visual bonita onde dá para testar as rotas.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Fecha o contêiner
var app = builder.Build();



// Configure the HTTP request pipeline.
// Uma trava de segurança. Diz que a interface visual do Swagger só deve ser ligada se o projeto estiver rodando em ambiente de Desenvolvimento (na sua máquina). 
// Quando o projeto for para produção (para a nuvem/servidor real), o Swagger fica desativado para que pessoas externas não vejam a estrutura da sua API.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseHttpsRedirection(); // Se alguém tentar acessar a sua API usando http://, o .NET intercepta e redireciona automaticamente para https:// (garantindo criptografia e segurança nos dados trafegados).
app.UseAuthorization();// Prepara o terreno para o sistema de segurança. Se futuramente você colocar restrições de login ou níveis de acesso (como "Apenas administradores podem deletar produtos"), essa linha garante que a API verifique essas permissões.
app.MapControllers();// Cria os caminhos (as rotas). Ela mapeia e liga as URLs digitadas no navegador/Postman diretamente aos métodos correspondentes que você escreveu no ProdutoController.

app.Run();


