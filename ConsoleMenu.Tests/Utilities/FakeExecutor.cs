using ConsoleMenu.Contracts;
using ConsoleMenu.Entities;
using ConsoleMenu.Enum;

namespace ConsoleMenu.Tests.Utilities
{
    public class FakeExecutor : IConsoleMenuExecutor
    {
        public int ExecutionCount { get; private set; }

        public Task<MenuExecutionResult> ExecuteAsync(ConsoleMenuOption option)
        {
            ExecutionCount++;

            var result = option.Kind == 
                ConsoleMenuOptionKind.Exit ?
                MenuExecutionResult.Exit :
                MenuExecutionResult.Continue;

            return Task.FromResult(result);
        }
    }
}
