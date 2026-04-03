using ConsoleMenu.Contracts;

namespace ConsoleMenu.Tests.Utilities
{
    public class FakeWrapper : IConsoleMenuWrapper
    {
        public bool SkipPause { get; set; } = true;

        private readonly Queue<ConsoleKeyInfo> _keys = new();

        public List<string> WrittenLines { get; } = new();
        public List<(string Message, ConsoleColor Color)> ColoredLines { get; } = new();

        public void ContinueAfterInput()
        {
            if (SkipPause) return;

            ColoredLines.Add(("\nPress any key to continue!", ConsoleColor.Green));
            ReadKey();
        }

        public void Clear() { }

        public void EnqueueKey(char key) => _keys.Enqueue(new ConsoleKeyInfo(key, (ConsoleKey)char.ToUpperInvariant(key), false, false, false));

        public ConsoleKeyInfo ReadKey() => _keys.Dequeue();

        public void WriteLine(string value = null!) => WrittenLines.Add(value ?? string.Empty);

        public void WriteLineColored(string value, ConsoleColor color) => ColoredLines.Add((value, color));
    }
}
