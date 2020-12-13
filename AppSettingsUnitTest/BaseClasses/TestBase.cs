using System.Collections.Generic;
using ConfigurationHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppsettingsUnitTest.BaseClasses
{
    public class TestBase
    {
        protected TestContext TestContextInstance;
        public TestContext TestContext
        {
            get => TestContextInstance;
            set
            {
                TestContextInstance = value;
                TestResults.Add(TestContext);
            }
        }

        public static IList<TestContext> TestResults;
        private static bool _testMode = false;

        public static GeneralSettings GeneralSettings() => Helper.Configuration(); 
    }
}
