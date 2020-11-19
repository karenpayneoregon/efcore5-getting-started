using System;

namespace IncludeFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            Setup();

            Operations.FilterPost("Cheese");
            Console.WriteLine("Press the (any) key");
            Console.ReadLine();

        }

        private static void Setup()
        {
            var originalForeColor = Console.ForegroundColor;

            Console.WriteLine(new string('-', 50));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("EF Core 5: Filtered Include");

            Console.ForegroundColor = originalForeColor;
            Console.WriteLine(new string('-', 50));

        }
    }
}
