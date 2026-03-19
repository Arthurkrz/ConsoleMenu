namespace ConsoleMenu.Contracts
{
    public interface IConsoleWrapper
    {
        void WriteLine(string value = null!);
        void WriteLineColored(string value, ConsoleColor color);
        ConsoleKeyInfo ReadKey();
    }
}