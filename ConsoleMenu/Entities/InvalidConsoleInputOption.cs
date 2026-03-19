namespace ConsoleMenu.Entities
{
    public class InvalidConsoleInputOption : CustomEnumeration
    {
        public InvalidConsoleInputOption(int id, string value) : base(id, value) { }

        public InvalidConsoleInputOption(string value) : base(99, value) { }
    }
}