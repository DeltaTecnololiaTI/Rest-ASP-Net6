using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Chassi.API.Projeto.Config.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection SwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.ConfigureOptions<ConfigureSwaggerOptions>();
            return services;
        }

        public static WebApplication SwaggerUi(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                var apiVersionDescriptionProvider =
                    app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

                app.UseSwagger();

                app.UseSwaggerUI(options =>
                {
                    foreach (var d in apiVersionDescriptionProvider.ApiVersionDescriptions.Reverse())
                    {
                        options.SwaggerEndpoint($"/swagger/{d.GroupName}/swagger.json", d.GroupName.ToUpperInvariant());
                    }
                });
            }

            return app;
        }
    }
}
