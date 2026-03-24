using ConsoleMenu.ManualTests.Contracts.Service;

namespace ConsoleMenu.ManualTests.Services
{
    public class AuditService : IAuditService
    {
        public void Register(string message) => Console.WriteLine($"Audit log: {message}");
    }
}
