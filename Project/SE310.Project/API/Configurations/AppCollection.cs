using Microsoft.OpenApi.Models;

namespace API.Configurations
{
    public static class AppCollections
    {
        public static void AddSwaggerServices(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //services.AddSwaggerGen();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MonkeyAPI",
                    Version = "v1.0",
                    Description = "OpenApi documentation for Puppy Application",
                    TermsOfService = new Uri("https://github.com/pmquoc-uit"),
                    Contact = new OpenApiContact
                    {
                        Name = "Monkey",
                        Email = "pmquoc@gmail.com",
                        Url = new Uri("https://github.com/pmquoc-uit"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Monkey License",
                        Url = new Uri("https://github.com/pmquoc-uit"),
                    }
                });
                options.AddServer(new OpenApiServer
                {
                    Description = "DEV",
                    Url = "https://localhost:5001",
                });
                options.AddServer(new OpenApiServer
                {
                    Description = "PROD",
                    Url = "https://pmquoc.com/monkey",
                });
            });
        }
    }
}
