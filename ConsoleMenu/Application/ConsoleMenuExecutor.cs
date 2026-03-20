using ConsoleMenu.Contracts;
using ConsoleMenu.Entities;

namespace ConsoleMenu.Application
{
    public class ConsoleMenuExecutor : IConsoleMenuExecutor
    {
        private readonly IEnumerable<IConsoleMenuHandler> _handlers;

        public ConsoleMenuExecutor(IEnumerable<IConsoleMenuHandler> handlers)
        {
            _handlers = handlers;
        }

        public void Execute(ConsoleMenuOption option)
        {
            ArgumentNullException.ThrowIfNull(option);

            if (option.Action is not null)
            {
                option.Action();
                return;
            }

            if (!string.IsNullOrWhiteSpace(option.HandlerKey))
            {
                var handler = _handlers.FirstOrDefault(x => x.Key == option.HandlerKey);

                if (handler is null)
                    throw new InvalidOperationException($"No handler registered for key '{option.HandlerKey}'.");

                handler.Execute();
                return;
            }

            throw new InvalidOperationException("Option has no action or handler key configured.");
        }
    }
}
