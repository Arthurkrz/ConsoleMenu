using ConsoleMenu.Application;

namespace ConsoleMenu
{
    public class Program
    {
        static void Main(string[] args)
        {
            var console = new ConsoleWrapper();
            var menu = new ConsoleMenuSelector(console);
        }
    }
}
