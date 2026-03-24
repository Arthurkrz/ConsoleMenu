using ConsoleMenu.ManualTests.Contracts.Service;

namespace ConsoleMenu.ManualTests.Services
{
    public class ReportService : IReportService
    {
        private readonly IAuditService _auditService;

        public ReportService(IAuditService auditService)
        {
            _auditService = auditService;
        }

        public void GenerateDailyReport()
        {
            _auditService.Register("Daily report requested.");
            Console.WriteLine("Daily report generated.");
        }
    }
}
