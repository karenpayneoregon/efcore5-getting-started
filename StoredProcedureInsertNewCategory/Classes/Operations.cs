using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoredProcedureInsertNewCategory.Context;

namespace StoredProcedureInsertNewCategory.Classes
{
    public class Operations
    {
        /// <summary>
        /// Insert new category
        /// </summary>
        /// <param name="categoryName">Category name required</param>
        /// <param name="description">Category description</param>
        public static void InsertCategory(string categoryName, string description)
        {
            using var context = new NorthWindContext();
            try
            {
                var parameters = new[] {
                    new SqlParameter("@CategoryName", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input, 
                        Value = categoryName
                    },
                    new SqlParameter("@Description", SqlDbType.NText)
                    {
                        Direction = ParameterDirection.Input, 
                        Value = description
                    },
                    new SqlParameter("@Identity", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output, 
                        Value = 0
                    }

                };
                context.Database.ExecuteSqlRaw(
                    "exec uspInsertCategory @CategoryName,@Description,@Identity out", parameters: 
                    parameters);

                var newPrimaryKey = Convert.ToInt32(parameters[2].Value);
                Debug.WriteLine(newPrimaryKey.ToString());


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
