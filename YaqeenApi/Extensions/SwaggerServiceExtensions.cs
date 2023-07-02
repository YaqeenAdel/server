namespace YaqeenApi.Extensions;
public static class SwaggerServiceExtensions
{
    public static IServiceCollection AddSwaggerDocs(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(setupAction =>
        {
            setupAction.AddSecurityDefinition("YaqeenApiBearerAuthentication",
                new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    Description = "Input a valid token without Bearer keyword"
                });

            setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "YaqeenApiBearerAuthentication",
                            Type = ReferenceType.SecurityScheme
                        }
                    }, new List<string>() }
            });
        });

        return services;
    }
}
