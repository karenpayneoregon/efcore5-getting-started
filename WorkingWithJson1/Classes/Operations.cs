using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using WorkingWithJson1.Context;
using WorkingWithJson1.Models;

namespace WorkingWithJson1.Classes
{
    public class Operations
    {
        public static List<Person> GetPersons()
        {
            using var context = new SampleContext();
            return context.People.ToList();
        }

        public static void Add()
        {
            var person = new Person
            {
                FirstName = "Karen",
                LastName = "Payne",
                DateOfBirth = new DateTime(1956, 9, 24),
                Addresses = new List<Address>()
                {
                    new Address()
                    {
                        Type = "Business",
                        City = "Salem",
                        Company = "ABC",
                        Number = "1",
                        Street = "111 Orange Way"
                    },
                    new Address()
                    {
                        Type = "Home",
                        City = "Salem",
                        Company = "ABC",
                        Number = "2",
                        Street = "123 Green Ave"
                    }
                }
            };

            using var context = new SampleContext();
            context.People.Add(person);
            var results = context.SaveChanges();
            Debug.WriteLine(results);
        }
    }
}
