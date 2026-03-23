using ConsoleMenu.Tests.Contracts.Service;

namespace ConsoleMenu.Tests.Services
{
    public class InventoryService : IInventoryService
    {
        public void ReserveItems() => Console.WriteLine("Inventory checked and items reserved.");
    }
}
