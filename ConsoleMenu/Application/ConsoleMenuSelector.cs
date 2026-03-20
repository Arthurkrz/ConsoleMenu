using ConsoleMenu.Contracts;
using ConsoleMenu.Entities;

namespace ConsoleMenu.Application
{
    public class ConsoleMenuSelector : IConsoleMenuSelector
    {
        private readonly IConsoleWrapper _console;

        public ConsoleMenuSelector(IConsoleWrapper console)
        {
            _console = console;
        }

        public ConsoleMenuOption ObtainOption(IEnumerable<ConsoleMenuOption> options)
        {
            var optionList = options?.ToList() ?? throw new ArgumentNullException(nameof(options));

            if (optionList.Any())
                throw new InvalidOperationException("No options provided.");

            ShowOptions(optionList);

            while (true)
            {
                var response = AskAndReadOption();
                var selectedOption = MapToConsoleInputOption(response, optionList);

                if (selectedOption is not null)
                {
                    _console.WriteLineColored($"\n\"{selectedOption.Value}\" selected", ConsoleColor.Cyan);
                    return selectedOption;
                }

                _console.WriteLineColored($"\n\"{response}\" is not a value option.\n", ConsoleColor.Red);
            }
        }

        private ConsoleMenuOption? MapToConsoleInputOption(string userInput, IEnumerable<ConsoleMenuOption> options)
        {
            if (!int.TryParse(userInput, out var inputAsNumber))
                return null;

            return options.FirstOrDefault(x => x.Id == inputAsNumber);
        }
        
        private string AskAndReadOption()
        {
            _console.WriteLine("\nSelect an option:");
            return _console.ReadKey().KeyChar.ToString();
        }

        private void ShowOptions(IEnumerable<ConsoleMenuOption> options)
        {
            _console.WriteLine();

            foreach (var option in options)
                _console.WriteLine($"[{option.Id}] - {option.Value}");
        }
    }
}
