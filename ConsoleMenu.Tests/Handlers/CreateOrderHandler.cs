using ConsoleMenu.Contracts;
using ConsoleMenu.Tests.Contracts.Service;

namespace ConsoleMenu.Tests.Handlers
{
    public class CreateOrderHandler : IConsoleMenuHandler
    {
        private readonly IOrderService _orderService;

        public CreateOrderHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public void Execute() => _orderService.CreateOrder();

        public string Key => "create-order";
    }
}
