namespace ConsoleMenu.Entities
{
    public sealed class ConsoleMenuOption
    {
        public ConsoleMenuOption(int id, string value, Action? action, string? handlerKey)
        {
            Id = id;
            Value = value;
            Action = action;
            HandlerKey = handlerKey;
        }

        public int Id { get; }
        public string Value { get; }
        public Action? Action { get; }
        public string? HandlerKey { get; }

        public static ConsoleMenuOption Create(int id, string value, Action action)
        {
            ArgumentNullException.ThrowIfNull(action);
            return new ConsoleMenuOption(id, value, action, null);
        }

        public static ConsoleMenuOption CreateWithHandler(int id, string value, string handlerKey)
        {
            if (string.IsNullOrWhiteSpace(handlerKey))
                throw new ArgumentException("Handler key cannot be empty.");

            return new ConsoleMenuOption(id, value, null, handlerKey);
        }
    }
}
