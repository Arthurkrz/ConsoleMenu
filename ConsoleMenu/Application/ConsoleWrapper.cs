using ConsoleMenu.Contracts;

namespace ConsoleMenu.Application
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public ConsoleKeyInfo ReadKey() => Console.ReadKey();

        public void WriteLine(string value = null!) => Console.WriteLine(value);

        public void WriteLineColored(string value, ConsoleColor color)
        {
            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ResetColor();
        }
    }
}
