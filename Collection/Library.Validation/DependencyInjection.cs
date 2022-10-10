using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using MediatR;
using Library.Validation.Behaviours;
using Microsoft.AspNetCore.Mvc;

namespace Library.Validation;
public static class DependencyInjection
{
    public static IServiceCollection AddAppCollection(this IServiceCollection services, Assembly currentAssembly) {
        //services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

        services.AddValidatorsFromAssembly(currentAssembly);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        return services;
    }
}
