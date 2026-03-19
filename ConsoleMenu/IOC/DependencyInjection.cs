using ConsoleMenu.Application;
using ConsoleMenu.Contracts;
using ConsoleMenu.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleMenu.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddGenericOptions(this IServiceCollection services)
        {
            services.AddSingleton<IConsoleWrapper, ConsoleWrapper>();
            services.AddSingleton<IConsoleInputOptionSelector<CustomEnumeration>, ConsoleInputOptionSelector<CustomEnumeration>>();
            return services;
        }
    }
}