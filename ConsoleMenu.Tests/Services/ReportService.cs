using ConsoleMenu.Tests.Contracts.Service;

namespace ConsoleMenu.Tests.Services
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
