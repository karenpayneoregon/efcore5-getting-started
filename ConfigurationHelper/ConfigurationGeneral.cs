using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationHelper
{
    public class ConfigurationGeneral
    {
        public string IncomingFolder { get; set; }
        public bool LogExceptions { get; set; }
        public DatabaseSettings DatabaseSettings { get; set; }
    }
}
