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

        public By InputFormLink = By.XPath("(//a[contains(text(),'Input Forms')])[2]");
        public By Checkbox = By.XPath("(//a[contains(text(),'Checkbox Demo')])[2]");
        public By CheckAllButton = By.XPath("//input[@Id='check1']");
        public By ChangedButton = By.XPath("//input[@id='isChkd']");
        public By Checkboxes = By.XPath("//div[@class='panel panel-default']/div[contains(text(),'Multiple')]//following::input[@type='checkbox']");
        public By Checkbox1 = By.XPath("(//div[@class='checkbox']//input)[2]");
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
        ///Method to get text
        /// </summary>
        public string MessageText()
        {
            IWebElement Text = Driver.FindElement(Message);
            String MText = Text.Text;
            return MText;
        }

        //<summary>
        ///Method to click InputFormLink
        /// </summary>
        public void ClickInputFormLink()
        {
            page.Click(InputFormLink);

        }

        //<summary>
        ///Method to click CheckBoxDemoLink
        /// </summary>
        public void ClickCheckBoxDemoLink()
        {
            page.Click(Checkbox);
        }

        //<summary>
        ///Method to click CheckAllBtn
        /// </summary>
        public void ClickCheckAllBtn()
        {
            page.Click(CheckAllButton);
        }

        //<summary>
        ///Method to verify Button name changed using Valur attribute
        /// </summary>
        public bool BtnNameChanged()
        {
            IWebElement BtnEle = Driver.FindElement(ChangedButton);
            string BtnValue = BtnEle.GetAttribute("value");
            if (BtnValue.Equals("true"))
            {
                return true;
            }
            return false;
        }

        //<summary>
        ///Method to verify if all checkboxes checked
        /// </summary>
        public bool VerifyAllCheckBoxesChecked()
        {
            IList<IWebElement> SelectedCheckBoxes = Driver.FindElements(Checkboxes);
            foreach(IWebElement ele in SelectedCheckBoxes)
            {
                if (ele.Selected)
                    return true;
            }
            return false;
        }

        //<summary>
        ///Method to uncheck a selected checkbox
        /// </summary>
        public void UnCheckACheckBox()
        {
            page.Click(Checkbox1);
        }
    }
}
