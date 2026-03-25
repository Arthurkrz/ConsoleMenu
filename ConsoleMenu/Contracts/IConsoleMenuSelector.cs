using ConsoleMenu.Entities;

namespace ConsoleMenu.Contracts
{
    public interface IConsoleMenuSelector
    {
        ConsoleMenuOption ObtainOption(IEnumerable<ConsoleMenuOption> options);
    }
}