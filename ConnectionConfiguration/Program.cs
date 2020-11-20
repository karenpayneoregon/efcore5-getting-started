using System;
using System.Linq;
using ConnectionConfiguration.Context;

namespace ConnectionConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connection code sample");
            using var context = new SchoolContext();
            var people = context.People.OrderBy(p => p.LastName).ToList();
            
            foreach (var person in people)
            {
                Console.WriteLine($"{person.PersonID, -4}{person.FullName}");
            }

            Console.ReadLine();
        }
    }
}
