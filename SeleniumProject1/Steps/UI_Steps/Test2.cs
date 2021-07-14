using AventStack.ExtentReports;
using NUnit.Framework;
using SeleniumProject1.Test_Utilities;
using SeleniumProject1.Test_Utilities.Reporting;
using SeleniumProject1.WebPages.TestPages;
using System;

namespace SeleniumProject1.Steps.UI_Steps
{
    [TestFixture]
    public class Test2 : TestBase
    {

        MessageDemoPage MessageDemoPage;

        String UserMessage;
        ExtentTest test = null;
        [Test]
        [Category("Smoke Test")]
        [Author("Subadhra Raja")]
        public void ShowMessageTest()
        {
            try
            {
                ReportHandler.getinstance();
                test = ReportHandler.extent.CreateTest("GoogleSearch").Info("Test Started");
                test.Log(Status.Info, " Chrome Browser Launched");
                GivenTheUserNavigatesToDemoSite();
                WhenTheUserClicksInPutForms();
                WhenTheUserClicksCheckBoxDemo();
                //ThenThebulletsareDisplayed();

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

        public void GivenTheUserNavigatesToDemoSite()
        {
            MessageDemoPage = NavigateToDemoSite("https://www.seleniumeasy.com/test/basic-first-form-demo.html");
            
        }
        public void WhenTheUserClicksInPutForms()
        {
            MessageDemoPage.ExitPopup();

            MessageDemoPage.ClickInputForm();
        }
        public void WhenTheUserClicksCheckBoxDemo()
        {
            MessageDemoPage.ClickCheckBoxDemoLink();

        }

        public void WhenTheUserClcikMultipleCheckBoxDemo()
        {
            MessageDemoPage.ClickCheckBoxDemoLink();

        }
       











    }
}
