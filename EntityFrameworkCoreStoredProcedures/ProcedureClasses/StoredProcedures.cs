using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoredProcedureEntityFrameworkCore1.Context;
using StoredProcedureEntityFrameworkCore1.Extensions;
using StoredProcedureEntityFrameworkCore1.Models;

namespace StoredProcedureEntityFrameworkCore1.ProcedureClasses
{
    public partial class StoredProcedures
    {
        private readonly NorthwindContext _context;

        public StoredProcedures(NorthwindContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Stored procedure to get customers by country identifier
        /// </summary>
        /// <param name="countryIdentifier"></param>
        /// <returns></returns>
        public async Task<CustomersByCountryIdentifierStoredProcedure[]> UspCustomersByCountryIdentifier(int? countryIdentifier)
        {
            var parameterCountryIdentifier = new SqlParameter
            {
                ParameterName = "CountryIdentifier",
                Precision = 10,
                Size = 4,
                SqlDbType = System.Data.SqlDbType.Int,
                Value = countryIdentifier,
            };

            CustomersByCountryIdentifierStoredProcedure[] result = await _context
                .SqlQuery<CustomersByCountryIdentifierStoredProcedure>("EXEC [dbo].[uspCustomersByCountryIdentifier] @CountryIdentifier  ",
                    parameterCountryIdentifier);

            return result;
        }

        public async Task<List<string>> CustomersByCountryIdentifier(int? countryIdentifier)
        {
            return await Task.Run(async () =>
            {
                var customerResults = await UspCustomersByCountryIdentifier(countryIdentifier);
                return customerResults.Select(cust => cust.FirstName).ToList();
            });

        }

        public async Task<uspGetCustomers1Result[]> UspGetCustomers1()
        {

            return await Task.Run(async () =>
            {
                var result = await _context.SqlQuery<uspGetCustomers1Result>("EXEC [dbo].[uspGetCustomers1]");

                return result;
            });

        }
    }
}
