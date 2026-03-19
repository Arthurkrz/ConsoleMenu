using ConsoleMenu.Application;
using ConsoleMenu.Entities;

namespace ConsoleMenu
{
    public class Program
    {
        static void Main(string[] args)
        {
            var console = new ConsoleWrapper();
            var menu = new ConsoleInputOptionSelector<CustomEnumeration>(console);
            menu.ObtainOption(options);
        }
    }
}
