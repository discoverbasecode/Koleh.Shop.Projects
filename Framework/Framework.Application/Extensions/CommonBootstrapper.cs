using Framework.Application.ValidationExtensions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Application.Extensions;

    public static class CommonBootstrapper
    {
        public static IServiceCollection RegisterCommonApplication(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
            return services;
        }
    }

