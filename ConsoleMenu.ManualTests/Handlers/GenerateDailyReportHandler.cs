using ConsoleMenu.Contracts;
using ConsoleMenu.ManualTests.Contracts.Service;

namespace ConsoleMenu.ManualTests.Handlers
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
