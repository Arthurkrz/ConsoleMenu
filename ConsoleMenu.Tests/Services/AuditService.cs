using ConsoleMenu.Tests.Contracts.Service;

namespace ConsoleMenu.Tests.Services
{
    public class AuditService : IAuditService
    {
        public void Register(string message) => Console.WriteLine($"Audit log: {message}");
    }
}
