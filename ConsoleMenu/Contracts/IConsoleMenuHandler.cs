namespace ConsoleMenu.Contracts
{
    public interface IConsoleMenuHandler
    {
        void Execute();
        string Key { get; }
    }
}
