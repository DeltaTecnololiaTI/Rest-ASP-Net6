using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Chassi.API.Projeto.Config.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

            //options.EnableAnnotations();

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Insira o token no padrão: Bearer {seu token}",
                Name = "Authorization",
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        }

        private static OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = "Projeto de Exemplo",
                Description = "API para retorno de dados de exemplo de um CRUD.",
                Contact = new OpenApiContact
                {
                    Name = "Meu email de contato",
                    Email = "mailto:delta.tecnologia.ti@gmail.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Meu tipo de licença",
                    Url = new Uri("https://exemplo.com/licenca")
                },
                Version = description.ApiVersion.ToString()
            };

            if (description.IsDeprecated)
            {
                info.Description +=
                    " Esta versão da API foi depreciada, por favor utilizar uma mais recente disponível.";
            }

            return info;
        }
    }
}
