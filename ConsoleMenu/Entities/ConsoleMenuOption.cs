using ConsoleMenu.Enum;

namespace ConsoleMenu.Entities
{
    public sealed class ConsoleMenuOption
    {
        private ConsoleMenuOption(int id, string value, ConsoleMenuOptionKind kind, Action? action = null, string? handlerKey = null)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException("ID must be greater than zero.");
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Value cannot be empty.");

            Id = id;
            Value = value;
            Kind = kind;
            Action = action;
            HandlerKey = handlerKey;
        }

        public int Id { get; }
        public string Value { get; }
        public ConsoleMenuOptionKind Kind { get; }
        public Action? Action { get; }
        public string? HandlerKey { get; }

        public static ConsoleMenuOption Create(int id, string value, Action action)
        {
            ArgumentNullException.ThrowIfNull(action);
            return new ConsoleMenuOption(id, value, ConsoleMenuOptionKind.Action, action);
        }

        public static ConsoleMenuOption CreateWithHandler(int id, string value, string handlerKey)
        {
            if (string.IsNullOrWhiteSpace(handlerKey))
                throw new ArgumentException("Handler key cannot be empty.");

            return new ConsoleMenuOption(id, value, ConsoleMenuOptionKind.Handler, null, handlerKey);
        }

        public static ConsoleMenuOption CreateExit(int id, string value) =>
            new ConsoleMenuOption(id, value, ConsoleMenuOptionKind.Exit);
    }
}
