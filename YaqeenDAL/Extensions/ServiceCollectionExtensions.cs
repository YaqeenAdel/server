using Microsoft.EntityFrameworkCore;
using YaqeenDAL.Model;
using YaqeenDAL.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDAL(this IServiceCollection serviceCollection, string connectionString)
        {
            // Add Entity Framework DbContext with the connection string
            serviceCollection.AddDbContext<YaqeenDbContext>(options =>
            options.UseNpgsql(connectionString, b=>b.MigrationsAssembly("YaqeenApi")));

            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            return serviceCollection;
        }
    }
}
