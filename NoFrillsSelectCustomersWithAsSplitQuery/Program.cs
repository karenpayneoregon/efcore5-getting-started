using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NorthEntityLibrary.Classes;

namespace NoFrillsSelectCustomersWithAsSplitQuery
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Task.Delay(1);
            List<CustomerEntity> customersAsync = await CustomerOperations.AllCustomersAsync();
            Console.WriteLine(customersAsync.Count);
            //Setup();
            Console.ReadLine();
        }

        static void Setup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();
            var author = config.GetSection("database").Get<ApplicationSettings>();
            Console.WriteLine();
        }
    }

}
