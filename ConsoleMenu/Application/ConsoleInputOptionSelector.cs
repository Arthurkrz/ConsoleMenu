using ConsoleMenu.Contracts;
using ConsoleMenu.Entities;

namespace ConsoleMenu.Application
{
    public class ConsoleInputOptionSelector<T> : IConsoleInputOptionSelector<T> where T : CustomEnumeration
    {
        private readonly IConsoleWrapper _console;

        public ConsoleInputOptionSelector(IConsoleWrapper console)
        {
            _console = console;
        }

        public T ObtainOption(IEnumerable<T> options)
        {
            ShowOptions(options);
            bool isValid;
            T selectedOption = default!;

            do
            {
                var response = AskAndReadOption();
                var option = MapToConsoleInputOption(response, options);
                isValid = IsSelectedOptionValid(option);
                selectedOption = isValid ? (T)option : selectedOption;
            } while (!isValid);

            return selectedOption;
        }

        private bool IsSelectedOptionValid(CustomEnumeration response)
        {
            if (response is InvalidConsoleInputOption)
            {
                _console.WriteLineColored($"\n\"{response.Value}\" is not a valid option.\n", ConsoleColor.Red);
                return false;
            }

            _console.WriteLineColored($"\n\"{response.Value}\" selected", ConsoleColor.Cyan);
            return true;
        }

        private CustomEnumeration MapToConsoleInputOption(string userInput, IEnumerable<CustomEnumeration> options)
        {
            if (!int.TryParse(userInput, out var inputAsNumber))
                return new InvalidConsoleInputOption(userInput);

            if (!options.Select(_ => _.Id).Contains(inputAsNumber))
                return new InvalidConsoleInputOption(userInput);

            return options.First(_ => _.Id == inputAsNumber);
        }

        private string AskAndReadOption()
        {
            _console.WriteLine("\nSelect an option from the list below:");
            return Console.ReadKey().KeyChar.ToString();
        }

        private void ShowOptions(IEnumerable<CustomEnumeration> options)
        {
            _console.WriteLine();

            foreach(var option in options)
                _console.WriteLine($"[{option.Id}] - {option.Value}");
        }
    }
}
