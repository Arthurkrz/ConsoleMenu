namespace ConsoleMenu.Contracts
{
    public interface IConsoleMenuHandler
    {
        string Key { get; }

        void Execute();
    }
}
