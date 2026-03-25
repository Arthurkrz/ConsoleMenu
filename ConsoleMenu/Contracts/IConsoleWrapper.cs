namespace ConsoleMenu.Contracts
{
    public interface IConsoleWrapper
    {
        ConsoleKeyInfo ReadKey();
        void Clear();
        void ContinueAfterInput();
        void WriteLine(string value = null!);
        void WriteLineColored(string value, ConsoleColor color);
    }
}