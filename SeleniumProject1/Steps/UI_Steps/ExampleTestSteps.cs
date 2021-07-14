using AventStack.ExtentReports;
using NUnit.Framework;
using SeleniumProject1.Test_Utilities;
using SeleniumProject1.Test_Utilities.Reporting;
using SeleniumProject1.WebPages.ExampleTestPages;
using System;

namespace SeleniumProject1.Steps.UI_Steps
{
    [TestFixture]
    public class ExampleTestSteps : TestBase
    {

        HomePage HomePage;
        DemoHomePage DemoHomePage;
        DragAndDropPage DragAndDropPage;
        ExtentTest test = null;
        [Test]
        [Category("Smoke")]
        [Author("Subadhra Raja")]
        public void DragAndDropTest()
        {
            try
            {
                ReportHandler.getinstance();
                test = ReportHandler.extent.CreateTest("GoogleSearch").Info("Test Started");
                test.Log(Status.Info, " Chrome Browser Launched");
                GivenTheUserNavigatesToDragAndDropInDemoSite();
                WhenTheUserDropsAllElement();
                ThenDroppedElemtsAreDisplayedInTheList();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw e;
            }
            finally
            {
                ReportHandler.CloseReportInstance();
            }
        }

        public void GivenTheUserNavigatesToDragAndDropInDemoSite()
        {
            HomePage = NavigateToSite("https://www.seleniumeasy.com/");
            test.Log(Status.Info, "Url opened");
        }
        public void WhenTheUserDropsAllElement()
        {
            DemoHomePage =HomePage.ClickDemoButton();
            DragAndDropPage=DemoHomePage.NavigateToDragAndDropPage();
            DragAndDropPage.DropAllElements();
            test.Log(Status.Info, "Elements are Dropped..");

        }
        public void ThenDroppedElemtsAreDisplayedInTheList()
        {
            bool ElementsDropped = DragAndDropPage.VerifyAllElementsDropped();
            Assert.IsTrue(ElementsDropped, "Elements are not dropped properly");
            test.Log(Status.Pass, "Test Passed");
        }











    }
}
