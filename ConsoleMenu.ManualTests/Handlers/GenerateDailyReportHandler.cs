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

        public async Task ExecuteAsync() => await _reportService.GenerateDailyReportAsync();

        public string Key => "generate-daily-report";
    }
}
