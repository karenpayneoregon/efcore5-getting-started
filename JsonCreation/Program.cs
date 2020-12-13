using System;
using System.Diagnostics;
using ConfigurationHelper;

namespace JsonCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateAppsettings();
            ConfigurationHelper.GeneralSettings settings = Helper.Configuration();
            Console.ReadLine();
        }

        static void CreateAppsettings()
        {
            var settings = new GeneralSettings
            {
                DatabaseSettings =
                    new DatabaseSettings()
                    {
                        DatabaseServer = ".\\SQLEXPRESS",
                        Catalog = "NorthWind2020",
                        IntegratedSecurity = true,
                        UsingLogging = true
                    },
                EmailSettings = new EmailSettings()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    DefaultCredentials = false,
                    EnableSsl = true,
                    PickupDirectoryLocation = "MailDrop"
                }
            };

            Debug.WriteLine(JsonConvertEx.SerializeObject(settings));
        }
    }
}
