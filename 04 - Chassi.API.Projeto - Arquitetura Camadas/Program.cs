using Chassi.API.Projeto.Business.Implementations;
using Chassi.API.Projeto.Business.Interface;
using Chassi.API.Projeto.Config.ApiVersion;
using Chassi.API.Projeto.Config.Swagger;
using Chassi.API.Projeto.Model.Context;
using Chassi.API.Projeto.Repository.Implementations;
using Chassi.API.Projeto.Repository.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IPessoaRepository, PessoaRepositoryImplementacao>();
builder.Services.AddScoped<IPessoaBusiness, PessoaBusinessImplementacao>();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<MySqlContext>(options => options.UseMySql
                                                (connection,
                                                 new MySqlServerVersion(new Version(8, 0, 1))
                                                )
                                             );

builder.Services.AddEndpointsApiExplorer();

// Adicionando classes de Configure Api Versioning de versionamento e Swagger personalizado
builder.Services.ConfigureApiVersioning();

// Adicionando classes de Swagger Extensions de versionamento e Swagger personalizado
builder.Services.SwaggerGen();

var app = builder.Build();

app.SwaggerUi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();