using ConsoleMenu.Entities;

namespace ConsoleMenu.Contracts
{
    public interface IConsoleMenuSelector<T> where T : CustomEnumeration
    {
        T ObtainOption(IEnumerable<T> options);
    }
}