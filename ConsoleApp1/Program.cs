using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            //if (int.TryParse(input, out var age))
            //{
            //    Console.WriteLine(age > 18 ? $"You are over 18" : "You are not over 18");
            //}
            //else
            //{
            //    Console.WriteLine($"Invalid input {input}");
            //}
            int.TryParse(input, out var test);

           

            Console.ReadLine();
        }

        
    }
}
