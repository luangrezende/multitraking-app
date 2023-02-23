namespace Correios.App.Helpers
{
    public static class ConsoleInterfaceHelper
    {
        public static void WriteLineWithColor(string value, ConsoleColor foreColor = ConsoleColor.White)
        {
            var oldForeColor = Console.ForegroundColor;
            Console.ForegroundColor = foreColor;
            Console.WriteLine(value);
            Console.ForegroundColor = oldForeColor;
        }

        public static void WriteWithColor(string value, ConsoleColor foreColor = ConsoleColor.White)
        {
            var oldForeColor = Console.ForegroundColor;
            Console.ForegroundColor = foreColor;
            Console.Write(value);
            Console.ForegroundColor = oldForeColor;
        }
    }
}
