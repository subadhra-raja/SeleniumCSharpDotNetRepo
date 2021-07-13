using OpenQA.Selenium;
using SeleniumProject1.Test_Utilities;
using SeleniumProject1.WebPages.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumProject1.WebPages.ExampleTestPages
{
    public class HomePage:TestBase
    {

        IWebDriver Driver;
        /// <summary>
        /// Default Constructor
        /// </summary>
        public HomePage(IWebDriver driver)
        {
            this.Driver = driver;
        }
        #region
        public By DemoButton = By.XPath("//div[@class='content']//a[contains(text(),'Demo Website!')]");
        #endregion

        ///<summary>
        ///Method to Drag And Drop elements
        /// </summary>
        public DemoHomePage ClickDemoButton()
        {
            BasePage page = new BasePage(Driver);
            page.Click(DemoButton);
            return new DemoHomePage(driver);
        }
    }
}
