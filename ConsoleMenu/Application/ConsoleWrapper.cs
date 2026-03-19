using ConsoleMenu.Contracts;

namespace ConsoleMenu.Application
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public ConsoleKeyInfo ReadKey() => Console.ReadKey();

        public void WriteLine(string value) => Console.WriteLine(value);

        public void WriteLineColored(string value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            WriteLine(value);
            Console.ResetColor();
        }
    }
}
