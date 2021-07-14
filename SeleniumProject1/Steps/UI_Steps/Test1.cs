using AventStack.ExtentReports;
using NUnit.Framework;
using SeleniumProject1.Test_Utilities;
using SeleniumProject1.Test_Utilities.Reporting;
using SeleniumProject1.WebPages.TestPages;
using System;

namespace SeleniumProject1.Steps.UI_Steps
{
    [TestFixture]
    public class Test1 : TestBase
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
                test = ReportHandler.extent.CreateTest("ShowMessageTest").Info("Test Started");
                test.Log(Status.Info, "Chrome Browser Launched");
                GivenTheUserNavigatesToDemoSite();
                GivenTheUserEntersAMessageInTheInputBox();
                WhenTheUserClicksOnTheShowMessageButton();
                ThenTheUserEnteredTextIsDisplayed();

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
            test.Log(Status.Info, "Url opened");
        }
        public void GivenTheUserEntersAMessageInTheInputBox()
        {
            MessageDemoPage.ExitPopup();
            UserMessage = "QA assessment trial #1";
            MessageDemoPage.EnterMessage(UserMessage);
            test.Log(Status.Info, "Message entered.");

        }
        public void WhenTheUserClicksOnTheShowMessageButton()
        {
            MessageDemoPage.ClickShowMessageBtn();
            test.Log(Status.Info, "Message Button Clicked.");

        }
        public void ThenTheUserEnteredTextIsDisplayed()
        {
            Assert.AreEqual(MessageDemoPage.MessageText(), UserMessage, "The User Message doesn't match");
            test.Log(Status.Pass, "Test completed successfully");
        }

    }
}
