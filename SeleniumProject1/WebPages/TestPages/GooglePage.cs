using OpenQA.Selenium;
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
       /// <summary>
        /// Default Constructor
        /// </summary>
        public GooglePage( IWebDriver driver)
        {
           this.Driver = driver;
        }
        #region
        public By SearchBox = By.XPath("//input[@title='Search']");
        public By SearchButton = By.XPath("//input[@type='submit']");
        #endregion

        ///<summary>
        ///Method to enter Text in the search box 
        /// </summary>
        ///<param name="text"></param>
        public SearchListPage SearchText(string text)
        {
            BasePage page = new BasePage(Driver);
            page.TypeText(SearchBox, text);
            page.Click(SearchButton);
            return new SearchListPage(driver);
        }

    }
}
