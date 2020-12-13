using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static System.IO.File;
using static System.DateTime;

namespace ExceptionHandling
{
    /// <summary>
    /// Provides writing run time exceptions to a text file
    /// </summary>
    /// <remarks>
    /// What's here works while there will be many modifications later on.
    /// </remarks>
    public static class Exceptions
    {
        public static bool Enabled { get; set; } = true;
        /// <summary>
        /// Write Exception information to UnhandledException.txt in the executable folder.
        /// </summary>
        /// <param name="exception">Strong typed <seealso cref="Exception"/></param>
        /// <param name="exceptionLogType">Type of exception which determines which file to log to. Not passing this parameter will default to the general log file</param>
        public static void Write(Exception exception, ExceptionLogType exceptionLogType = ExceptionLogType.General)
        {
            if (!Enabled) return;

            var fileName = "";

            switch (exceptionLogType)
            {
                case ExceptionLogType.File:
                    fileName = "FileUnhandledException.txt";
                    break;
                case ExceptionLogType.Data:
                    fileName = "DataUnhandledException.txt";
                    break;
                case ExceptionLogType.General:
                    fileName = "GeneralUnhandledException.txt";
                    break;
            }

            try
            {
                if (Exists(fileName))
                {
                    var contents = ReadAllText(fileName);
                    var current = ToLogString(exception, Environment.StackTrace);
                    var data = $"{contents}{Environment.NewLine}{current}{Environment.NewLine}";
                    WriteAllText(fileName, data);
                }
                else
                {
                    WriteAllText(fileName, ToLogString(exception, Environment.StackTrace) + Environment.NewLine);
                }
            }
            catch
            {
                // ignored - we are in no position to handle this other than protect the service from crashing.
            }
        }


        /// <summary>
        ///  Provides full stack trace for the exception that occurred.
        /// </summary>
        /// <param name="exception">Exception object.</param>
        /// <param name="environmentStackTrace">Environment stack trace, for pulling additional stack frames.</param>
        /// <returns>Formatted exception with stack trace</returns>
        public static string ToLogString(this Exception exception, string environmentStackTrace)
        {
            var environmentStackTraceLines = GetUserStackTraceLines(environmentStackTrace);
            environmentStackTraceLines.RemoveAt(0);

            var stackTraceLines = GetStackTraceLines(exception.StackTrace);
            stackTraceLines.AddRange(environmentStackTraceLines);

            var fullStackTrace = string.Join(Environment.NewLine, stackTraceLines);

            return exception.Message + Environment.NewLine + fullStackTrace;
        }
        /// <summary>
        ///  Gets a list of stack frame lines, as strings.
        /// </summary>
        /// <param name="stackTrace">Stack trace string.</param>
        /// <returns>Stack trace lines</returns>
        private static List<string> GetStackTraceLines(string stackTrace) => stackTrace.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
        /// <summary>
        ///  Gets a list of stack frame lines, as strings, only including those for which line number is known.
        /// </summary>
        /// <param name="fullStackTrace">Full stack trace, including external code.</param>
        /// <returns>Stack trace lines</returns>
        private static List<string> GetUserStackTraceLines(string fullStackTrace)
        {
            var outputList = new List<string>();
            var regex = new Regex(@"([^\)]*\)) in (.*):line (\d)*$");

            List<string> stackTraceLines = GetStackTraceLines(fullStackTrace);

            foreach (var stackTraceLine in stackTraceLines)
            {
                if (!regex.IsMatch(stackTraceLine))
                {
                    continue;
                }

                outputList.Add(stackTraceLine);
            }

            return outputList;
        }
    }
}