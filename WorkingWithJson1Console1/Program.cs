using System;
using System.Linq;

using WorkingWithJson1.Classes;
using WorkingWithJson1.Models;

namespace WorkingWithJson1Console1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Operations.Add();
            var personJsonAddresses = Operations.GetPersons().FirstOrDefault()?.AddressJson;
            //var addresses = person?.Addresses;
            Console.WriteLine(personJsonAddresses);

            //Sample.Instance.People.Add(new Person() {FirstName = "Karen", LastName = "Payne"});
            
            //Console.WriteLine(Sample.Instance.People.Count);

            //foreach (var person in Sample.Instance.People)
            //{
            //    Console.WriteLine($"{person.FirstName} {person.LastName}");
            //}
            Console.ReadLine();
        }
    }
}
