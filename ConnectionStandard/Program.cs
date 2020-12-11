using System;
using System.Linq;
using ConnectionStandard.Contexts;

namespace ConnectionStandard
{
    class Program
    {
        private static void Main(string[] args)
        {

            Example1();


            Example2();

            Console.ReadLine();
        }

        /// <summary>
        /// Read connection string in SchoolContext
        /// </summary>
        private static void Example1()
        {
            using var context = new SchoolContext();
            var people = context.People.ToList();
            Console.WriteLine(people.Count);
        }
        /// <summary>
        /// Create SchoolContext in factory class
        /// </summary>
        private static void Example2()
        {
            using var context = ContextFactory.CreateDbContext();
            var people = context.People.ToList();
            Console.WriteLine(people.Count);
        }
    }
}
