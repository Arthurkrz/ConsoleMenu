using ConsoleMenu.Application;
using ConsoleMenu.Contracts;
using ConsoleMenu.Entities;
using ConsoleMenu.Tests.Contracts.Service;
using ConsoleMenu.Tests.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleMenu.Tests
{
    public class Startup
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly IConsoleMenuSelector _consoleMenuSelector;
        private readonly IConsoleMenuExecutor _consoleMenuExecutor;

        public Startup(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            _consoleMenuSelector = _serviceProvider.GetRequiredService<IConsoleMenuSelector>();
            _consoleMenuExecutor = _serviceProvider.GetRequiredService<IConsoleMenuExecutor>();
        }

        public void ExecuteWithoutHandlers()
        {
            IInventoryService inventoryService = new InventoryService();
            IOrderService orderService = new OrderService(inventoryService);

            IAuditService auditService = new AuditService();
            IReportService reportService = new ReportService(auditService);

            var menu = new ConsoleMenuSetup();

            menu.AddOption(1, "Create order", () => orderService.CreateOrder())
                .AddOption(1, "Generate daily report", () => reportService.GenerateDailyReport())
                .AddExitOption(3, "Exit");

            menu.Run();
        }

        public void ExecuteWithHandlers()
        {
            var menu = new ConsoleMenuSetup(_consoleMenuSelector, _consoleMenuExecutor);

            menu.AddHandlerOption(1, "Create order", "create-order")
                .AddHandlerOption(2, "Generate daily report", "generate-daily-report")
                .AddExitOption(3, "Exit");

            menu.Run();
        }
    }
}
