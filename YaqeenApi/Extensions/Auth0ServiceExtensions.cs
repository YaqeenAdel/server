namespace YaqeenApi.Extensions;
public static class Auth0ServiceExtensions
{
    public static IServiceCollection AddAuth0Services(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.Authority = $"https://{config["Auth0:Domain"]}/";
                options.Audience = config["Auth0:Audience"];
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    NameClaimType = ClaimTypes.NameIdentifier, // Strange
                    ValidTypes = new[] { "JWT" }
                };
            });

        return services;
    }
}
