using Microsoft.Extensions.DependencyInjection;
using Service.Queries.DTOs.Profiles;
using System.Reflection;

namespace Service.Queries.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddQuery(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapperQueries));

        services.AddTransient<IDebtorQuery, DebtorQuery>();        

        return services;
    }
}
