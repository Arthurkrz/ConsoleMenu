using ConsoleMenu.Application;
using ConsoleMenu.Contracts;
using ConsoleMenu.Entities;
using ConsoleMenu.Tests.Contracts.Handler;
using ConsoleMenu.Tests.Contracts.Service;
using ConsoleMenu.Tests.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleMenu.Tests
{
    public class Startup
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly IAuditService _auditService;
        private readonly IInventoryService _inventoryService;
        private readonly IOrderService _orderService;
        private readonly IReportService _reportService;

        private readonly ICreateOrderHandler _createOrderHandler;
        private readonly IGenerateDailyReportHandler _generateDailyReportHandler;

        private readonly IConsoleMenuSelector _consoleMenuSelector;
        private readonly IConsoleMenuExecutor _consoleMenuExecutor;

        public Startup(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            _auditService = _serviceProvider.GetRequiredService<IAuditService>();
            _inventoryService = _serviceProvider.GetRequiredService<IInventoryService>();
            _orderService = _serviceProvider.GetRequiredService<IOrderService>();
            _reportService = _serviceProvider.GetRequiredService<IReportService>();

            _createOrderHandler = _serviceProvider.GetRequiredService<ICreateOrderHandler>();
            _generateDailyReportHandler = _serviceProvider.GetRequiredService<IGenerateDailyReportHandler>();

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

            menu.AddOption(1, "Create order", () => orderService.CreateOrder());
            menu.AddOption(2, "Generate daily report", () => reportService.GenerateDailyReport());

            menu.Run();
        }

        public void ExecuteWithHandlers()
        {
            var options = new List<ConsoleMenuOption>
            {
                ConsoleMenuOption.CreateWithHandler(1, "Create order", "create-order"),
                ConsoleMenuOption.CreateWithHandler(2, "Generate daily report", "generate-daily-report")
            };

            var selectedOption = _consoleMenuSelector.ObtainOption(options);
            _consoleMenuExecutor.Execute(selectedOption);
        }
    }
}
