using ConsoleMenu.Contracts;

namespace ConsoleMenu.Tests.Utilities
{
    public class FakeHandler : IConsoleMenuHandler
    {
        public string Key { get; }
        public bool IsExecuted { get; private set; }

        public FakeHandler(string key)
        {
            Key = key;
        }

        public void Execute() => IsExecuted = true;
    }
}
