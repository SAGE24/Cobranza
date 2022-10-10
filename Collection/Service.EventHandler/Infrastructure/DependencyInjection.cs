using Library.Validation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Service.EventHandler.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddEventHandler(this IServiceCollection services) {

        services.AddAppCollection(Assembly.GetExecutingAssembly());

        return services;
    }
}
