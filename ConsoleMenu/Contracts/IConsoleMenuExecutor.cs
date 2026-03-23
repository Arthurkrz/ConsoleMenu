using ConsoleMenu.Entities;

namespace ConsoleMenu.Contracts
{
    public interface IConsoleMenuExecutor
    {
        void Execute(ConsoleMenuOption option, bool clearBeforeSelection = true, bool clearAfterExecution = true);
    }
}