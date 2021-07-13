using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumProject1.Test_Utilities;
using SeleniumProject1.WebPages.TestPages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumProject1.Tests
{
    [TestFixture]
    public class GoogleTestSteps : TestBase
    {
        GooglePage GooglePage;
        SearchListPage SearchListPage;
        [Test]
        [Category("Smoke")]
        [Author("Subadhra Raja")]
        public void GoogleSearch()
        {
            try
            {
                GivenTheUserNavigatesToGoogleSearchPage();
                WhenTheUserSearchesAText();
                ThenTheSearchListPageIsLoaded();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw e;
            }
        }

        public void GivenTheUserNavigatesToGoogleSearchPage()
        {
            GooglePage = NavigateToGooglePage("http://google.com/");
        }
        public void WhenTheUserSearchesAText()
        {
            SearchListPage = GooglePage.SearchText("Test");
        }
        public void ThenTheSearchListPageIsLoaded()
        {
           bool LogoAvailable = SearchListPage.CheckIfLogoAvailable();
           Assert.IsTrue(LogoAvailable, "The Search result page is not Displayed");
        }











    }
}
