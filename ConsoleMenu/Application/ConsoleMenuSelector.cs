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

            if (!optionList.Any())
                throw new InvalidOperationException("No options provided.");

            ValidateDuplicateIds(optionList);
            ShowOptions(optionList);

            while (true)
            {
                var response = AskAndReadOption();
                var selectedOption = MapToConsoleInputOption(response, optionList);

                if (selectedOption is not null)
                {
                    _console.Clear();
                    _console.WriteLineColored($"\"{selectedOption.Value}\" selected\n", ConsoleColor.Cyan);
                    return selectedOption;
                }

                _console.Clear();
                _console.WriteLineColored($"\"{response}\" is not a valid option.\n", ConsoleColor.Red);
                ShowOptions(optionList);
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
            foreach (var option in options)
                _console.WriteLine($"[{option.Id}] - {option.Value}");
        }

        private static void ValidateDuplicateIds(IEnumerable<ConsoleMenuOption> options)
        {
            var duplicateIds = options
                .GroupBy(x => x.Id)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (duplicateIds.Any())
                throw new InvalidOperationException($"Duplicate option IDs found: {string.Join(", ", duplicateIds)}");
        }
    }
}
