using ConsoleMenu.Tests.Contracts.Service;

namespace ConsoleMenu.Tests.Services
{
    public class OrderService : IOrderService
    {
        private readonly IInventoryService _inventoryService;

        public OrderService(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public void CreateOrder()
        {
            _inventoryService.ReserveItems();
            Console.WriteLine("Order successfully created.");
        }
    }
}
