using ConsoleMenu.Contracts;
using ConsoleMenu.Tests.Contracts.Service;
using ConsoleMenu.Tests.Handlers;
using ConsoleMenu.Tests.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleMenu.Tests.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectServices(this IServiceCollection services)
        {
            services.AddSingleton<IAuditService, AuditService>();
            services.AddSingleton<IInventoryService, InventoryService>();
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IReportService, ReportService>();
            return services;
        }

        public static IServiceCollection InjectHandlers(this IServiceCollection services)
        {
            services.AddSingleton<IConsoleMenuHandler, CreateOrderHandler>();
            services.AddSingleton<IConsoleMenuHandler, GenerateDailyReportHandler>();
            return services;
        }
    }
}
