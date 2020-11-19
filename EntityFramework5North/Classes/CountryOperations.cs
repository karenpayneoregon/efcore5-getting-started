using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthEntityLibrary.Contexts;
using NorthEntityLibrary.Models;

namespace NorthEntityLibrary.Classes
{
    public class CountryOperations
    {
        /// <summary>
        /// Get all Countries for DataGridView ComboBox column
        /// </summary>
        /// <returns>List of countries</returns>
        public static async Task<List<Countries>> CountriesAsync()
        {
            await using var context = new NorthwindContext();

            return await Task.Run(() => context
                .Countries
                .AsNoTracking().ToListAsync());
        }

        public static async Task<List<Countries>> CountriesWithSelectAsync()
        {
            await using var context = new NorthwindContext();

            var countries = await Task.Run(() => context
                .Countries
                .AsNoTracking().ToListAsync());

            countries.Insert(0, new Countries() {CountryIdentifier = -1, Name = "Select"});

            return countries;

        }
    }
}
