using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    public enum ExceptionLogType
    {
        /// <summary>
        /// Common exceptions
        /// </summary>
        General,
        /// <summary>
        /// Database exceptions
        /// </summary>
        Data,
        /// <summary>
        /// File operation exceptions
        /// </summary>
        File
    }
}
