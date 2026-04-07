using ConsoleMenu.Enum;

namespace ConsoleMenu.Application
{
    /// <summary>
    /// Class representing an option in the console menu. It contains properties for the option's ID, 
    /// display value, kind (Action, Handler, or Exit), and optional action or handler key depending on the kind. 
    /// The class includes static factory methods for creating options of different kinds, ensuring 
    /// that the necessary properties are set correctly based on the option type.
    /// </summary>
    public sealed class ConsoleMenuOption
    {
        private ConsoleMenuOption(int id, string value, ConsoleMenuOptionKind kind, Func<Task>? asyncAction = null, string? handlerKey = null)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException("ID must be greater than zero.");
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Value cannot be empty.");

            Id = id;
            Value = value;
            Kind = kind;
            AsyncAction = asyncAction;
            HandlerKey = handlerKey;
        }

        /// <summary>
        /// Unique identifier for the menu option. Must be greater than zero.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Name of the menu option.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Enum value for identifying the type of the menu option, which can be Action, 
        /// Handler, or Exit. This determines how the option will be executed when selected.
        /// </summary>
        public ConsoleMenuOptionKind Kind { get; }

        /// <summary>
        /// Action delegate for simple configuration. Must be provided when Kind is Action, 
        /// and should be null when Kind is Handler or Exit.
        /// </summary>
        public Func<Task>? AsyncAction { get; }

        /// <summary>
        /// Key for handler binding, used when the option kind is Handler. 
        /// Cannot be empty or whitespace when Kind is Handler.
        /// </summary>
        public string? HandlerKey { get; }

        /// <summary>
        /// Creates a menu option of kind Action, used for simple configuration. 
        /// The HandlerKey is set to null for this kind, and an Action delegate must be provided.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static ConsoleMenuOption Create(int id, string value, Action action)
        {
            ArgumentNullException.ThrowIfNull(action);
            return new ConsoleMenuOption(id, value, ConsoleMenuOptionKind.Action, () =>
            {
                action();
                return Task.CompletedTask;
            });
        }

        /// <summary>
        /// Creates a menu option of kind Action, used for simple asynchoronus configuration. 
        /// The HandlerKey is set to null for this kind, and a Func of type Task with 
        /// an Action delegate must be provided.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static ConsoleMenuOption CreateAsync(int id, string value, Func<Task> action)
        {
            ArgumentNullException.ThrowIfNull(action);
            return new ConsoleMenuOption(id, value, ConsoleMenuOptionKind.Action, action);
        }

        /// <summary>
        /// Creates a menu option of kind Handler, used for complex configuration. 
        /// The Action is set to null for this kind, and the HandlerKey must be
        /// provided to link the option to a handler in the executor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <param name="handlerKey"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ConsoleMenuOption CreateWithHandler(int id, string value, string handlerKey)
        {
            if (string.IsNullOrWhiteSpace(handlerKey))
                throw new ArgumentException("Handler key cannot be empty.");

            return new ConsoleMenuOption(id, value, ConsoleMenuOptionKind.Handler, null, handlerKey);
        }

        /// <summary>
        /// Creates an exit option, setting the kind to Exit and leaving action and handlerKey as null.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ConsoleMenuOption CreateExit(int id, string value) =>
            new ConsoleMenuOption(id, value, ConsoleMenuOptionKind.Exit);
    }
}
