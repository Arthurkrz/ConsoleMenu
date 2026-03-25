using ConsoleMenu.Entities;
using ConsoleMenu.Enum;

namespace ConsoleMenu.Contracts
{
    public interface IConsoleMenuExecutor
    {
        MenuExecutionResult Execute(ConsoleMenuOption option);
    }
}