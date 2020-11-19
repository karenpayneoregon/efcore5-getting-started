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
            List<CustomerEntity> customersAsync = await CustomerOperations.AllCustomersAsync();
            Console.WriteLine(customersAsync.Count);
            Console.ReadLine();
        }
    }

}
