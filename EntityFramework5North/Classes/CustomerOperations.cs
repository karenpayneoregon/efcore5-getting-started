using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthEntityLibrary.Contexts;
using NorthEntityLibrary.Models;

namespace NorthEntityLibrary.Classes
{
    public class CustomerOperations
    {
        public static async Task<List<CustomerEntity>> AllCustomersAsync()
        {

            return await Task.Run(async () =>
            {
                await using var context = new NorthwindContext();
                List<CustomerEntity> customerItemsList = await context.Customers
                    .Include(customer => customer.Contact)
                    .Select(Customers.Projection)
                    .ToListAsync();

                return customerItemsList.OrderBy((customer) => customer.CompanyName).ToList();
            });
        }
        public static async Task<List<CustomerItem>> GetCustomersAsync()
        {

            var currentExecutable = Process.GetCurrentProcess().MainModule.FileName;

            return await Task.Run(async () =>
            {
                await using var context = new NorthwindContext();
                return await context.Customers.AsNoTracking()
                    .Include(customer => customer.Contact)
                    .ThenInclude(contact => contact.ContactDevices)
                    .ThenInclude(contactDevices => contactDevices.PhoneTypeIdentifierNavigation)
                    .Include(customer => customer.ContactTypeIdentifierNavigation)
                    .Include(customer => customer.CountryIdentifierNavigation)
                    .Select(customer => new CustomerItem()
                    {
                        CustomerIdentifier = customer.CustomerIdentifier,
                        CompanyName = customer.CompanyName,
                        ContactId = customer.Contact.ContactId,
                        Street = customer.Street,
                        City = customer.City,
                        PostalCode = customer.PostalCode,
                        CountryIdentifier = customer.CountryIdentifier,
                        Phone = customer.Phone,
                        ContactTypeIdentifier = customer.ContactTypeIdentifier,
                        Country = customer.CountryIdentifierNavigation.Name,
                        FirstName = customer.Contact.FirstName,
                        LastName = customer.Contact.LastName,
                        ContactTitle = customer.ContactTypeIdentifierNavigation.ContactTitle,
                        OfficePhoneNumber = customer.Contact.ContactDevices.FirstOrDefault(contactDevices => contactDevices.PhoneTypeIdentifier == 3).PhoneNumber
                    })
                    .TagWith($"App name: {currentExecutable}")
                    .TagWith($"From: {nameof(CustomerOperations)}.{nameof(GetCustomersAsync)}")
                    .TagWith("Parameters: None")
                    .ToListAsync();
            });
        }
        /// <summary>
        /// Export to text file by country name. There are more efficient ways to
        /// do this although the focus here is on 'Using declarations' of C# 8.
        /// </summary>
        /// <param name="customerItems"></param>
        /// <param name="countryName"></param>
        /// <returns></returns>
        public static int ToFile(IEnumerable<CustomerItem> customerItems, string countryName)
        {
            using var file = new System.IO.StreamWriter($"{countryName}.txt");

            int skipped = 0;

            foreach (CustomerItem customerItem in customerItems)
            {
                if (customerItem.Country == countryName)
                {
                    file.WriteLine(customerItem.ExportLine);
                }
                else
                {
                    skipped++;
                }
            }

            return skipped;
            // file is disposed here
        }
    }
}
