using System;
using System.Linq;
using System.Threading.Tasks;
using ConnectionStandard.Classes;
using ConnectionStandard.Contexts;

using Environment = ConnectionStandard.Classes.Environment;

namespace ConnectionStandard
{
    class Program
    {
        private static async Task Main(string[] args)
        {

            //Example1();

            await Example1A();

            //Example2();
            
            Console.ReadLine();
        }

        /// <summary>
        /// Read connection string in SchoolContext
        /// </summary>
        private static void Example1()
        {
            using var context = new SchoolContext();
            var people = context.People.ToList();
            Console.WriteLine($"Example 1 : {people.Count}");
        }
        private static async Task Example1A()
        {
            await using var context = new SchoolContext1();
            var settings = context.GetSettings();
            if (await context.TestConnectionTask())
            {
                var people = context.People.ToList();
                Console.WriteLine($"Example 1A: {people.Count}");
            }
            else
            {
                Console.WriteLine("Connection will fail");
            }

        }

        /// <summary>
        /// Create SchoolContext in factory class
        /// </summary>
        private static void Example2()
        {
            using var context = ContextFactory.CreateDbContext();
            var people = context.People.ToList();
            Console.WriteLine($"Example 2 : {people.Count}");
        }
    }
}
