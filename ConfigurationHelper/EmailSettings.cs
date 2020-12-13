namespace ConfigurationHelper
{
    public class EmailSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public bool DefaultCredentials { get; set; }
        public string PickupDirectoryLocation { get; set; }

    }
}
