using ConsoleMenu.Application;
using ConsoleMenu.Contracts;

namespace ConsoleMenu.Tests.Utilities
{
    public class FakeSelector : IConsoleMenuSelector
    {
        private readonly Queue<ConsoleMenuOption> _options;

        public FakeSelector(IEnumerable<ConsoleMenuOption> options)
        {
            _options = new Queue<ConsoleMenuOption>(options);
        }

        public ConsoleMenuOption ObtainOption(IEnumerable<ConsoleMenuOption> options) => _options.Dequeue();
    }
}
