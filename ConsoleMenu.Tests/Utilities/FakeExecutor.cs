using ConsoleMenu.Contracts;
using ConsoleMenu.Entities;
using ConsoleMenu.Enum;

namespace ConsoleMenu.Tests.Utilities
{
    public class FakeExecutor : IConsoleMenuExecutor
    {
        public int ExecutionCount { get; private set; }

        public MenuExecutionResult Execute(ConsoleMenuOption option)
        {
            ExecutionCount++;

            return option.Kind == ConsoleMenuOptionKind.Exit ?
                MenuExecutionResult.Exit :
                MenuExecutionResult.Continue;
        }
    }
}
