using ConsoleMenu.Contracts;
using ConsoleMenu.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleMenu.Application
{
    public class ConsoleMenuExecutor
    {
        private readonly IServiceProvider _serviceProvider;

        public ConsoleMenuExecutor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Execute(ConsoleMenuOption option)
        {
            if (option.Action is not null)
            {
                option.Action();
                return;
            }

            if (!string.IsNullOrWhiteSpace(option.HandlerKey))
            {
                var handlers = _serviceProvider.GetService<IConsoleMenuHandler>();
                var handler = handlers.FirstOrDefault(x => x.Key == option.HandlerKey);

                if (handler is null)
                    throw new InvalidOperationException($"No handler registered for key '{option.HandlerKey}'.");

                handler.Execute(option);
                return;
            }

            throw new InvalidOperationException("Option has no action or handler key configured.");
        }
    }
}
