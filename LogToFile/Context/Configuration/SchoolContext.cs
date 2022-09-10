using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ConfigurationHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;


// ReSharper disable once CheckNamespace - dealing with partial class
namespace LogToFile.Context
{
    public partial class SchoolContext
    {
        /// <summary>
        /// For logging to file via .LogTo
        /// </summary>
        private readonly StreamWriter _logStream = new StreamWriter(Helper.LogFileName(), append: true);
        
        private static void NoLogging(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Helper.ConnectionString());
        }
        /// <summary>
        /// Log information to Visual Studio's Output window
        /// </summary>
        /// <param name="optionsBuilder"></param>
        private static void LogQueryInfoToDebugOutputWindow(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Helper.ConnectionString())
                .EnableSensitiveDataLogging()
                .LogTo(message => Debug.WriteLine(message));
        }

        /// <summary>
        /// Log information to file
        /// </summary>
        /// <param name="optionsBuilder"></param>
        private void LogQueryInfoToFile(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Helper.ConnectionString())
                .EnableSensitiveDataLogging()
                .LogTo(message => _logStream.WriteLine(message), 
                    LogLevel.Information, 
                    DbContextLoggerOptions.Category);
        }
        /// <summary>
        /// Log when Includes are done
        /// </summary>
        /// <param name="optionsBuilder"></param>
        private void LogIncludesInfoToFile(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Helper.ConnectionString())
                .EnableSensitiveDataLogging()
                .LogTo(_logStream.WriteLine, new[]
                {
                    CoreEventId.NavigationBaseIncluded,
                });
        }

        private void LogQueryInfoToFIle1(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Helper.ConnectionString())
                .EnableSensitiveDataLogging()
                .LogTo(message => _logStream.WriteLine(message), 
                    LogLevel.Information);
        }

        #region Takes care of disposing stream used for logging
        public override void Dispose()
        {
            base.Dispose();
            _logStream.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await _logStream.DisposeAsync();
        }
        #endregion        
    }
}
