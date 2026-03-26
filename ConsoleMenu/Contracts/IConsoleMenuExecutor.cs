using ConsoleMenu.Entities;
using ConsoleMenu.Enum;

namespace ConsoleMenu.Contracts
{
    public interface IConsoleMenuExecutor
    {
        Task<MenuExecutionResult> ExecuteAsync(ConsoleMenuOption option);
    }
}