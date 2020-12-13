namespace JsonCreation
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
    }

}
