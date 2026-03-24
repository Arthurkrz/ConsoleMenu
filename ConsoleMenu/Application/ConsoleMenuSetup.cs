using ConsoleMenu.Contracts;
using ConsoleMenu.Entities;
using ConsoleMenu.Enum;

namespace ConsoleMenu.Application
{
    public sealed class ConsoleMenuSetup
    {
        private readonly List<ConsoleMenuOption> _options = new();

        private readonly IConsoleMenuSelector _selector;
        private readonly IConsoleMenuExecutor _executor;
        
        public ConsoleMenuSetup() 
            : this(new ConsoleMenuSelector(new ConsoleWrapper()), 
                   new ConsoleMenuExecutor([], new ConsoleWrapper())) { }

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

        public ConsoleMenuSetup AddHandlerOption(int id, string value, string handlerKey)
        {
            _options.Add(ConsoleMenuOption.CreateWithHandler(id, value, handlerKey));
            return this;
        }

        public ConsoleMenuSetup AddExitOption(int id, string value)
        {
            _options.Add(ConsoleMenuOption.CreateExit(id, value));
            return this;
        }

        public void Run()
        {
            while (true)
            {
                var selectedOption = _selector.ObtainOption(_options);
                var result = _executor.Execute(selectedOption);

                if (result == MenuExecutionResult.Exit) break;
            }
        }
    }
}
