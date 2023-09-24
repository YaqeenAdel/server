
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using YaqeenServices.DTOs;
using YaqeenServices.Services;
using YaqeenServices.Validations;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.ConfigureDAL(connectionString);
            serviceCollection.AddSingleton<IValidator<UserCreateDto>, UserCreateDtoValidator>();
            serviceCollection.AddScoped<IUserServices,UserServices>();
            return serviceCollection;
        }
    }
}
