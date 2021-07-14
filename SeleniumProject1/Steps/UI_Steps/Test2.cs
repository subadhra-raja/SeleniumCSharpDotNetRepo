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

        [Test]
        [Category("Smoke Test")]
        [Author("Subadhra Raja")]
        public void CheckBoxTest()
        {
            try
            {
                ReportHandler.getinstance();
                ReportHandler.extent.CreateTest("CheckBoxTest").Info("Test Started");
                NavigatesToDemoSite();
                ClicksInPutFormsLink();
                ClicksCheckBoxDemoLink();
                ClickCheckAllButton();
                VerifyAllCheckBoxesAreSelected();
                VerifyButtonNameChangesToUnCheckALL();
                UnCheckOneCheckbox();
                VerifyButtonNameChangesBackToCheckALL();
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

        public void NavigatesToDemoSite()
        {
            MessageDemoPage = NavigateToDemoSite("https://www.seleniumeasy.com/test/basic-first-form-demo.html");
            
        }
        public void ClicksInPutFormsLink()
        {
            MessageDemoPage.ExitPopup();
            MessageDemoPage.ClickInputFormLink();
        }
        public void ClicksCheckBoxDemoLink()
        {
            MessageDemoPage.ClickCheckBoxDemoLink();
        }

        public void ClickCheckAllButton()
        {
            MessageDemoPage.ClickCheckAllBtn();

        }
        public void VerifyAllCheckBoxesAreSelected()
        {
            Assert.IsTrue(MessageDemoPage.VerifyAllCheckBoxesChecked(), "All Checkboxes are not selected");
        }

        public void VerifyButtonNameChangesToUnCheckALL()
        {
            Assert.IsTrue(MessageDemoPage.BtnNameChanged(), "The Button namke is not changed");
        }

        public void UnCheckOneCheckbox()
        {
            MessageDemoPage.UnCheckACheckBox();

        }
        public void VerifyButtonNameChangesBackToCheckALL()
        {
            Assert.IsFalse(MessageDemoPage.BtnNameChanged(), "The Button name is not changed back to CheckALL");
        }

    }
}
