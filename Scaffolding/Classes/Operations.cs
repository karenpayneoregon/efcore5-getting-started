using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Text;
using ExceptionHandling;

namespace Scaffolding.Classes
{
    public class Operations
    {
        /// <summary>
        /// This will be variable server and catalog
        /// </summary>
        private static string ConnectionString = 
            "Data Source=.\\sqlexpress;Initial " +
            "Catalog=NorthWind2020;Integrated Security=True";

        /// <summary>
        /// Generate class from table name
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static string GenerateClass(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw  new ArgumentException(nameof(tableName) + " can not be empty");
            }

            if (tableName.Contains(" "))
            {
                throw new Exception(nameof(tableName) + " can not contain spaces");
            }

            string classDetails = "";

            using var cn = new SqlConnection { ConnectionString = ConnectionString };
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = cn;
                cmd.CommandText = "uspGenerateClass";
                cmd.CommandType = CommandType.StoredProcedure;

                // starting part for class generation
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@ClassInformation",
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Value = $"Public Class "
                });

                // table name to create class
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@TableName",
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Value = tableName
                });

                // class created
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Result",
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Output,
                    Size = -1
                });

                try
                {
                    cn.Open();

                    var results = cmd.ExecuteScalar();

                    if (results != null)
                    {
                        classDetails = Convert.ToString(results);
                    }

                }
                catch (Exception e)
                {
                    Exceptions.Write(e);
                }
            }

            return classDetails;
        }
        /// <summary>
        /// Get table names for database
        /// </summary>
        /// <returns></returns>
        public static List<string> TableNames()
        {
            var tableNameList = new List<string>();

            using var cn = new SqlConnection {ConnectionString = ConnectionString};
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = cn;
                cmd.CommandText = 
                    "SELECT TABLE_NAME FROM information_schema.tables " + 
                    "WHERE TABLE_TYPE='BASE TABLE' AND TABLE_SCHEMA = 'dbo' AND TABLE_NAME <> 'sysdiagrams' " + 
                    "ORDER BY TABLE_NAME";

                try
                {
                    cn.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            tableNameList.Add(reader.GetString(0));
                        }
                    }

                }
                catch (Exception e)
                {
                    Exceptions.Write(e);
                }
            }

            return tableNameList;
        }

    }
}
