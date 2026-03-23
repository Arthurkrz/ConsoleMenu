using ConsoleMenu.Tests.Contracts.Handler;
using ConsoleMenu.Tests.Contracts.Service;

namespace ConsoleMenu.Tests.Handlers
{
    public class GenerateDailyReportHandler : IGenerateDailyReportHandler
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
