using ConsoleMenu.Contracts;
using ConsoleMenu.Entities;

namespace ConsoleMenu.Application
{
    public sealed class ConsoleMenuSetup
    {
        private readonly List<ConsoleMenuOption> _options = new();
        private readonly IConsoleMenuSelector _selector;
        private readonly IConsoleMenuExecutor _executor;

        public ConsoleMenuSetup() : this(new ConsoleMenuSelector(new ConsoleWrapper()), new ConsoleMenuExecutor(null)) { }

        public ConsoleMenuSetup(IConsoleMenuSelector selector, IConsoleMenuExecutor executor)
        {
            _selector = selector;
            _executor = executor;
        }

        public ConsoleMenuSetup AddOption(int id, string value, Action action)
        {
            _options.Add(ConsoleMenuOption.Create(id, value, action));
            return this;
        }

        public void Run()
        {
            var selectedOption = _selector.ObtainOption(_options);
            _executor.Execute(selectedOption);
        }
    }
}
