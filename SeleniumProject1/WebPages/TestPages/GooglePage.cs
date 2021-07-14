using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject1.Test_Utilities;
using SeleniumProject1.WebPages.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumProject1.WebPages.TestPages
{
    
    public class GooglePage : TestBase
    {
        IWebDriver Driver;
        BasePage page;
       /// <summary>
       /// Default Constructor
       /// </summary>
        public GooglePage( IWebDriver driver)
        {
           this.Driver = driver;
            page = new BasePage(Driver);
        }
        #region
        public By SearchBox = By.XPath("//input[@title='Search']");
        public By SearchButton = By.XPath("(//input[@type='submit' and @class='gNO89b'])[1]");
        #endregion

        ///<summary>
        ///Method to enter Text in the search box 
        /// </summary>
        ///<param name="text"></param>
        public SearchListPage SearchText(string text)
        {
            page.TypeText(SearchBox, text);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SearchBox));
            page.Click(SearchButton);
            return new SearchListPage(driver);
        }
    }
}
