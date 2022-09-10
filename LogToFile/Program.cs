using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogToFile.Classes;
using LogToFile.Extensions;
using LogToFile.Models;

namespace LogToFile
{
    class Program
    {
        static async Task Main(string[] args)
        {

            //var people = await Operations.PeopleTask();

            await Operations.DemonstrationLoggingTask();
            
            //foreach (var person in people)
            //{
            //    Console.WriteLine(person.FullName);
            //}



            //people.ModeListToJson("people.json");
            //Console.ReadLine();
        }
    }
}
