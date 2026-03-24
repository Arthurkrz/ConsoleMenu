using ConsoleMenu.Contracts;
using ConsoleMenu.Tests.Contracts.Service;

namespace ConsoleMenu.Tests.Handlers
{
    public class GenerateDailyReportHandler : IConsoleMenuHandler
    {
        private readonly IReportService _reportService;

        public GenerateDailyReportHandler(IReportService reportService)
        {
            _reportService = reportService;
        }

        public void Execute() => _reportService.GenerateDailyReport();

        public string Key => "generate-daily-report";
    }
}
