using ConsoleMenu.Contracts;

namespace ConsoleMenu.Tests.UnitTests.Utilities
{
    public class FakeWrapper : IConsoleWrapper
    {
        private readonly Queue<ConsoleKeyInfo> _keys = new();

        public List<string> WrittenLines { get; } = new();
        public List<(string Message, ConsoleColor Color)> ColoredLines { get; } = new();

        public void ContinueAfterInput()
        {
            Console.WriteLine("\nPress any key to continue!", ConsoleColor.Green);
            Console.ReadKey();
        }

        public void Clear() => Console.Clear();

        public void EnqueueKey(char key) => _keys.Enqueue(new ConsoleKeyInfo(key, (ConsoleKey)char.ToUpperInvariant(key), false, false, false));

        public ConsoleKeyInfo ReadKey() => _keys.Dequeue();

        public void WriteLine(string value = null!) => WrittenLines.Add(value ?? string.Empty);

        public void WriteLineColored(string value, ConsoleColor color) => ColoredLines.Add((value, color));
    }
}
