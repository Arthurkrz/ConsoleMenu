using ConsoleMenu.Entities;

namespace ConsoleMenu.Contracts
{
    public interface IConsoleInputOptionSelector<T> where T : CustomEnumeration
    {
        T ObtainOption(IEnumerable<T> options);
    }
}