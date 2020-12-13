using System.Collections.Generic;
using AppsettingsUnitTest.BaseClasses;
using ConfigurationHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppsettingsUnitTest
{
    [TestClass(), TestCategory("Logging exceptions")]
    public class Tests : TestBase
    {
        [TestInitialize]
        public void Init()
        {
            //Console.WriteLine(TestContext.TestName);
        }
        /// <summary>
        /// Provides property information on the test class
        /// </summary>
        /// <param name="testContext"></param>
        /// <remarks>
        /// TestContext gets created in <see cref="TestBase"/>
        /// </remarks>
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            TestResults = new List<TestContext>();
        }
        [TestMethod]
        public void CheckDatabaseSettings()
        {
            GeneralSettings settings = GeneralSettings();

            Assert.IsTrue(settings.DatabaseSettings.DatabaseServer == ".\\SQLEXPRESS", "DatabaseSettings.DatabaseServer failed");
            Assert.IsTrue(settings.DatabaseSettings.Catalog == "NorthWind2020", "DatabaseSettings.Catalog failed");
            Assert.IsTrue(settings.DatabaseSettings.IntegratedSecurity == true, "DatabaseSettings.IntegratedSecurity failed");
            Assert.IsTrue(settings.DatabaseSettings.UsingLogging, "DatabaseSettings.UsingLogging failed");

            var expectedConnectionString =
                "Data Source=.\\SQLEXPRESS;Initial Catalog=NorthWind2020;Integrated Security=True";

            Assert.IsTrue(settings.DatabaseSettings.ConnectionString == expectedConnectionString);
        }

        [TestMethod]
        public void CheckEmailSetting()
        {
            GeneralSettings settings = GeneralSettings();

            Assert.IsTrue(settings.EmailSettings.Host == "smtp.gmail.com", "EmailSettings.Host failed");
            Assert.IsTrue(settings.EmailSettings.Port == 587, "EmailSettings.Port failed");
            Assert.IsTrue(settings.EmailSettings.EnableSsl, "EmailSettings.EnableSsl failed");
            Assert.IsTrue(settings.EmailSettings.DefaultCredentials == false, "EmailSettings.DefaultCredentials failed");
            Assert.IsTrue(settings.EmailSettings.PickupDirectoryLocation == "MailDrop", "EmailSettings.PickupDirectoryLocation failed");

        }

        [TestMethod]
        public void UpdateEmailSettings()
        {
            GeneralSettings settings = GeneralSettings();

            Assert.IsTrue(settings.EmailSettings.DefaultCredentials == false, "EmailSettings.DefaultCredentials failed");
            settings.EmailSettings.DefaultCredentials = true;
            Helper.UpdateEmail(settings.EmailSettings);

            Assert.IsTrue(settings.EmailSettings.DefaultCredentials == true, "Update failed");
        }

    }
}
