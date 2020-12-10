using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoredProcedureEntityFrameworkCore1.Context;
using StoredProcedureEntityFrameworkCore1.Models;

namespace StoredProcedureEntityFrameworkCore1.Classes
{
    public class CustomerOperations
    {
        public static async Task<List<CustomerEntity>> AllCustomersAsync()
        {

            return await Task.Run(async () =>
            {

                /*
                 * C# 8
                 * Using declarations
                 * A using declaration is a variable declaration preceded by the using keyword.
                 * It tells the compiler that the variable being declared should be disposed
                 * at the end of the enclosing scope. 
                 */
                await using var context = new NorthwindContext();

                /*
                 * EF Core 5, although the single query remains the default, you have the option to
                 * force the query to be split up with the AsSplitQuery method. Like the AsNoTracking
                 * method, there's also a way to apply this to the context itself, not only particular
                 * queries.
                 */
                List<CustomerEntity> customerItemsList = await context.Customers
                    .AsSplitQuery()
                    .Include(customer => customer.Contact)
                    .Select(Customers.Projection)
                    .ToListAsync();

                return customerItemsList.OrderBy((customer) => customer.CompanyName).ToList();
            });
        }

    }
}
