using ConsoleMenu.Contracts;
using ConsoleMenu.Entities;

namespace ConsoleMenu.Application
{
    public class ConsoleMenuExecutor : IConsoleMenuExecutor
    {
        private readonly IEnumerable<IConsoleMenuHandler> _handlers;

        public ConsoleMenuExecutor(IEnumerable<IConsoleMenuHandler>? handlers)
        {
            _handlers = handlers?.ToList() ?? new List<IConsoleMenuHandler>();
            ValidateDuplicateHandlerKeys(_handlers);
        }

        public void Execute(ConsoleMenuOption option, bool clearBeforeSelection = true, bool clearAfterExecution = true)
        {
            ArgumentNullException.ThrowIfNull(option);

            if (option.Action is not null)
            {
                if (clearBeforeSelection) Console.Clear();

                option.Action();

                if (clearAfterExecution) Console.Clear();
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

        private static void ValidateDuplicateHandlerKeys(IEnumerable<IConsoleMenuHandler> handlers)
        {
            var duplicateKeys = handlers
                .GroupBy(x => x.Key)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (duplicateKeys.Any())
                throw new InvalidOperationException($"Duplicate handler keys found: {string.Join(", ", duplicateKeys)}");
        }
    }
}
