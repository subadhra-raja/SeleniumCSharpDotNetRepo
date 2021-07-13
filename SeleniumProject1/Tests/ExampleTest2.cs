using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumProject1.Test_Utilities;
using SeleniumProject1.WebPages.ExampleTestPages;
using SeleniumProject1.WebPages.TestPages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumProject1.Tests
{
    [TestFixture]
    public class ExampleTest2 : TestBase
    {

        HomePage HomePage;
        DemoHomePage DemoHomePage;
        TPPage TPPage;
        TDSPage TDSPage;
        [Test]
        [Category("Smoke")]
        [Author("Subadhra Raja")]
        public void TableTest()
        {
            try
            {
                HomePage = NavigateToSite("https://www.seleniumeasy.com/");
                DemoHomePage = HomePage.ClickDemoButton();
                DemoHomePage.ExitPopup();
                TPPage = DemoHomePage.NavigateToTP();
                TPPage.NavigateTable();
                TDSPage = TPPage.NavigateToTDS();
                bool SearchSuccessful = TDSPage.SearchTable("Wireframes");
                Assert.IsTrue(SearchSuccessful, "Search not Successful");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw e;
            }
        }
    }
}
