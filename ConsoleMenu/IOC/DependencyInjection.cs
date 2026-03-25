using ConsoleMenu.Application;
using ConsoleMenu.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleMenu.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddConsoleMenu(this IServiceCollection services)
        {
            services.AddSingleton<IConsoleWrapper, ConsoleWrapper>();
            services.AddSingleton<IConsoleMenuSelector, ConsoleMenuSelector>();
            services.AddSingleton<IConsoleMenuExecutor, ConsoleMenuExecutor>();

            return services;
        }
    }
}