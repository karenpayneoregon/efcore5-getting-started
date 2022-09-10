namespace ConfigurationHelper
{
    /// <summary>
    /// Properties for setting up a connection string
    /// </summary>
    public class DatabaseSettings
    {
        public string DatabaseServer { get; set; }
        public string Catalog { get; set; }
        public bool IntegratedSecurity { get; set; }
        public bool UsingLogging { get; set; }
        public LoggingDistination LoggingDistination { get; set; }
        public string LogFileName { get; set; }
        
        public string ConnectionString => $"Data Source={DatabaseServer};" +
                                          $"Initial Catalog={Catalog};" +
                                          $"Integrated Security={IntegratedSecurity}";

    }
}
