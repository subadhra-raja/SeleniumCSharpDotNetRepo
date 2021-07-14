using AventStack.ExtentReports;
using NUnit.Framework;
using SeleniumProject1.Test_Utilities;
using SeleniumProject1.Test_Utilities.Reporting;
using SeleniumProject1.WebPages.TestPages;
using System; 

namespace SeleniumProject1.Steps.UI_Steps
{
    [TestFixture]
    public class GoogleTestSteps : TestBase
    {
        GooglePage GooglePage;
        SearchListPage SearchListPage;
        ExtentTest test = null;
        [Test]
        [Category("Smoke")]
        [Author("Subadhra Raja")]
        public void GoogleSearch()
        {
            try
            {
                ReportHandler.getinstance();
                test = ReportHandler.extent.CreateTest("GoogleSearch").Info("Test Started");
                test.Log(Status.Info, " Chrome Browser Launched");
                GivenTheUserNavigatesToGoogleSearchPage();
                WhenTheUserSearchesAText();
                ThenTheSearchListPageIsLoaded();
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw e;
            }
            finally
            {
                ReportHandler.CloseReportInstance();
            }
        }

        public void GivenTheUserNavigatesToGoogleSearchPage()
        {
            GooglePage = NavigateToGooglePage("http://google.com/");
            test.Log(Status.Info, "Url opened");
        }
        public void WhenTheUserSearchesAText()
        {
            SearchListPage = GooglePage.SearchText("Test");
            test.Log(Status.Info, " Text being Searched..");
        }
        public void ThenTheSearchListPageIsLoaded()
        {
           bool LogoAvailable = SearchListPage.CheckIfLogoAvailable();
           Assert.IsTrue(LogoAvailable, "The Search result page is not Displayed");
           test.Log(Status.Pass, "Test Passed");
        }
    }
}
