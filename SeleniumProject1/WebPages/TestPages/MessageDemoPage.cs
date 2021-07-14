using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject1.Test_Utilities;
using SeleniumProject1.WebPages.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumProject1.WebPages.TestPages
{
    
    public class MessageDemoPage : TestBase
    {
        IWebDriver Driver;
        BasePage page;
       /// <summary>
       /// Default Constructor
       /// </summary>
        public MessageDemoPage( IWebDriver driver)
        {
           this.Driver = driver;
            page = new BasePage(Driver);
        }
        #region
        public By AdvPopup = By.XPath("//div[@class='at-cv-goal-container']");
        public By AdvExitBtn = By.XPath("//div/a[contains(text(),'No, thanks!')]");

        public By InputBox = By.Id("user-message");
        public By ShowMessageBTn = By.XPath("//button[contains(text(),'Show Message')]");
        public By Message = By.XPath("//span[@Id='display']");

        public By InputFormLink = By.XPath("//a[contains(text(),'Input Forms')]");
        public By Checkbox = By.XPath("(//a[contains(text(),'Checkbox Demo')])[2]");
        #endregion


        ///<summary>
        ///Method to exit out the Add popup
        /// </summary>
        public void ExitPopup()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            IWebElement Modalcontainer = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(AdvPopup));
            IWebElement modalContent = Modalcontainer.FindElement(AdvExitBtn);
            Thread.Sleep(3000);
            modalContent.Click();

        }
        ///<summary>
        ///Method to enter Text in the input box 
        /// </summary>
        ///<param name="text"></param>
        public void EnterMessage(string text)
        {
            page.TypeText(InputBox, text);                    
        }
        //<summary>
        ///Method to click Show message
        /// </summary>
        public void ClickShowMessageBtn()
        {                       
            page.Click(ShowMessageBTn);
        }

        //<summary>
        ///Method to verify text
        /// </summary>
        public string MessageText()
        {
            IWebElement Text = Driver.FindElement(Message);
            String MText = Text.Text;
            return MText;
        }

        public void ClickInputForm()
        {
            page.Click(InputFormLink);

        }

        public void ClickCheckBoxDemoLink()
        {
            page.Click(Checkbox);
        }

        public void verifyText()
        {

        }
    }
}
