using System;
using System.Threading.Tasks;
using LogToFile.Classes;

namespace LogToFile
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var people = await Operations.PeopleTask();

            foreach (var person in people)
            {
                Console.WriteLine(person.FullName);
            }
            Console.ReadLine();
        }
    }
}
