using ConsoleMenu.Contracts;
using ConsoleMenu.Entities;
using ConsoleMenu.Enum;

namespace ConsoleMenu.Application
{
    public class ConsoleMenuExecutor : IConsoleMenuExecutor
    {
        private readonly IEnumerable<IConsoleMenuHandler> _handlers;
        private readonly IConsoleWrapper _console;

        public ConsoleMenuExecutor(IEnumerable<IConsoleMenuHandler>? handlers, IConsoleWrapper console)
        {
            _handlers = handlers?.ToList() ?? new List<IConsoleMenuHandler>();
            ValidateDuplicateHandlerKeys(_handlers);

            _console = console;
        }

        public async Task<MenuExecutionResult> ExecuteAsync(ConsoleMenuOption option)
        {
            ArgumentNullException.ThrowIfNull(option);

            switch (option.Kind)
            {
                case ConsoleMenuOptionKind.Action:
                    if (option.AsyncAction is null)
                        throw new InvalidOperationException($"Option '{option.Value}' has no action configured.");

                    await option.AsyncAction();
                    _console.ContinueAfterInput();
                    _console.Clear();
                    return MenuExecutionResult.Continue;

                case ConsoleMenuOptionKind.Handler:
                    if (string.IsNullOrWhiteSpace(option.HandlerKey))
                        throw new InvalidOperationException($"Option '{option.HandlerKey}' has no handler registered.");

                    var handler = _handlers.FirstOrDefault(x => x.Key == option.HandlerKey);

                    if (handler is null)
                        throw new InvalidOperationException($"Option '{option.HandlerKey}' has no handler registered.");

                    await handler.ExecuteAsync();
                    _console.ContinueAfterInput();
                    _console.Clear();
                    return MenuExecutionResult.Continue;

                case ConsoleMenuOptionKind.Exit:
                    return MenuExecutionResult.Exit;

                default:
                    throw new InvalidOperationException(
                        $"Unsupported option kind '{option.Kind}'.");
            }
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
